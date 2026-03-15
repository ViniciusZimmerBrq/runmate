using Microsoft.AspNetCore.Mvc;
using RunMate.Application.Auth.Commands;
using RunMate.Application.Auth.Validators;

namespace RunMate.Api.Endpoints;

public static class AuthEndpoints
{
    public static IEndpointRouteBuilder MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/auth").WithTags("Auth");

        group.MapPost("/register", RegisterAsync)
            .Produces(StatusCodes.Status201Created)
            .Produces<ValidationErrorResponse>(StatusCodes.Status400BadRequest)
            .Produces<ErrorResponse>(StatusCodes.Status409Conflict);

        group.MapPost("/login", LoginAsync)
            .Produces<LoginResponse>(StatusCodes.Status200OK)
            .Produces<ErrorResponse>(StatusCodes.Status401Unauthorized);

        return app;
    }

    private static async Task<IResult> RegisterAsync(
        [FromBody] RegisterRequest request,
        RegisterUserCommandHandler handler,
        CancellationToken cancellationToken)
    {
        if (request is null)
            return Results.BadRequest(new ValidationErrorResponse(["Request body is required."]));

        try
        {
            var command = new RegisterUserCommand
            {
                Name = request.Name ?? string.Empty,
                Email = request.Email ?? string.Empty,
                Password = request.Password ?? string.Empty,
            };

            var result = await handler.HandleAsync(command, cancellationToken);

            return Results.Created(
                $"/api/users/{result.UserId}",
                new RegisterResponse(result.UserId, result.Name, result.Email));
        }
        catch (ValidationException ex)
        {
            return Results.BadRequest(new ValidationErrorResponse(ex.Errors));
        }
        catch (EmailAlreadyInUseException)
        {
            return Results.Conflict(new ErrorResponse("Email address is already registered."));
        }
    }

    private static async Task<IResult> LoginAsync(
        [FromBody] LoginRequest request,
        LoginUserCommandHandler handler,
        CancellationToken cancellationToken)
    {
        if (request is null)
            return Results.Unauthorized();

        try
        {
            var command = new LoginUserCommand
            {
                Email = request.Email ?? string.Empty,
                Password = request.Password ?? string.Empty,
            };

            var result = await handler.HandleAsync(command, cancellationToken);

            return Results.Ok(new LoginResponse(
                AccessToken: result.AccessToken,
                ExpiresInSeconds: result.ExpiresInSeconds,
                User: new UserDto(result.UserId, result.Name, result.Email)));
        }
        catch (InvalidCredentialsException)
        {
            // Generic message to prevent user enumeration
            return Results.Unauthorized();
        }
    }
}

// --- Request / Response contracts for this module ---

public sealed record RegisterRequest(string? Name, string? Email, string? Password);

public sealed record LoginRequest(string? Email, string? Password);

public sealed record RegisterResponse(Guid UserId, string Name, string Email);

public sealed record LoginResponse(string AccessToken, int ExpiresInSeconds, UserDto User);

public sealed record UserDto(Guid UserId, string Name, string Email);

public sealed record ErrorResponse(string Message);

public sealed record ValidationErrorResponse(IReadOnlyList<string> Errors);
