using Microsoft.AspNetCore.Mvc;
using RunMate.Api.Configuration;
using RunMate.Application.Auth.Commands;
using RunMate.Application.Auth.Dtos;
using RunMate.Application.Auth.Interfaces;
using RunMate.Application.Auth.Validators;
using RunMate.Application.Dtos;
using RunMate.Infrastructure.Persistence;
using RunMate.Infrastructure.Security;

var builder = WebApplication.CreateBuilder(args);

var jwtSettings = builder.Configuration
    .GetSection(JwtSettings.SectionName)
    .Get<JwtSettings>() ?? new JwtSettings();

if (!builder.Environment.IsDevelopment() && string.IsNullOrWhiteSpace(jwtSettings.Secret))
{
    throw new InvalidOperationException(
        "JWT secret is missing. Configure Jwt:Secret or JWT__Secret before starting the API.");
}

var userStoreOptions = builder.Configuration
    .GetSection(FileUserStoreOptions.SectionName)
    .Get<FileUserStoreOptions>() ?? new FileUserStoreOptions();

if (!Path.IsPathRooted(userStoreOptions.Path))
{
    userStoreOptions.Path = Path.Combine(builder.Environment.ContentRootPath, userStoreOptions.Path);
}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(userStoreOptions);
builder.Services.AddSingleton<IUserRepository, JsonUserRepository>();
builder.Services.AddSingleton<IPasswordHashService, Pbkdf2PasswordHashService>();
builder.Services.AddSingleton<RegisterUserCommandHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.MapGet("/health/config", () => Results.Ok(new
{
    JwtIssuer = jwtSettings.Issuer,
    JwtAudience = jwtSettings.Audience,
    HasJwtSecret = !string.IsNullOrWhiteSpace(jwtSettings.Secret),
    Environment = builder.Environment.EnvironmentName,
}));

app.MapGet("/api/dashboard/weekly-summary", () =>
    Results.Ok(
        new WeeklySummaryDto(
            DistanceInKm: 18.4,
            CompletedWorkouts: 4,
            AveragePace: "5:32/km",
            GoalProgress: 74)));

app.MapGet("/api/workouts", () =>
    Results.Ok(
        new[]
        {
            new WorkoutDto(
                Id: Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Title: "Rodagem leve",
                PerformedAt: new DateTime(2026, 3, 12, 6, 30, 0, DateTimeKind.Utc),
                DistanceInKm: 5.0,
                DurationInMinutes: 29,
                Pace: "5:48/km"),
        }));

app.MapPost(
    "/api/auth/register",
    async (
        [FromBody] RegisterRequest request,
        RegisterUserCommandHandler handler,
        CancellationToken cancellationToken) =>
{
    var validationErrors = RegisterRequestValidator.Validate(request);
    if (validationErrors.Count > 0)
    {
        return Results.ValidationProblem(validationErrors);
    }

    var result = await handler.HandleAsync(request, cancellationToken);
    if (result.EmailAlreadyExists)
    {
        return Results.Conflict(
            new ProblemDetails
            {
                Title = "Email already registered",
                Detail = "An account with this email already exists.",
                Status = StatusCodes.Status409Conflict,
            });
    }

    return Results.Created(
        $"/api/users/{result.User!.UserId}",
        result.User);
});

app.MapPost("/api/auth/login", ([FromBody] LoginRequestDto request) =>
{
    return Results.Ok(
        new AuthResponseDto(
            AccessToken: "dev-token",
            RefreshToken: "dev-refresh-token",
            ExpiresInSeconds: 3600,
            UserName: request.Email));
});

app.Run();
