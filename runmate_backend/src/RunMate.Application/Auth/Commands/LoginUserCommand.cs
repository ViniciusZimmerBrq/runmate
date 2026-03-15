using RunMate.Application.Auth.Interfaces;
using RunMate.Application.Auth.Validators;
using RunMate.Domain.Repositories;

namespace RunMate.Application.Auth.Commands;

public sealed class LoginUserCommand
{
    public required string Email { get; init; }
    public required string Password { get; init; }
}

public sealed class LoginUserResult
{
    public required string AccessToken { get; init; }
    public int ExpiresInSeconds { get; init; }
    public Guid UserId { get; init; }
    public required string Name { get; init; }
    public required string Email { get; init; }
}

public sealed class LoginUserCommandHandler
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHashService _passwordHashService;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginUserCommandHandler(
        IUserRepository userRepository,
        IPasswordHashService passwordHashService,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _passwordHashService = passwordHashService;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<LoginUserResult> HandleAsync(
        LoginUserCommand command,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(command.Email) || string.IsNullOrWhiteSpace(command.Password))
            throw new InvalidCredentialsException();

        var user = await _userRepository.FindByEmailAsync(command.Email, cancellationToken);
        if (user is null)
            throw new InvalidCredentialsException();

        var passwordValid = _passwordHashService.VerifyPassword(user.PasswordHash, command.Password);
        if (!passwordValid)
            throw new InvalidCredentialsException();

        var (accessToken, expiresInSeconds) = _jwtTokenGenerator.GenerateToken(user.Id, user.Email, user.Name);

        return new LoginUserResult
        {
            AccessToken = accessToken,
            ExpiresInSeconds = expiresInSeconds,
            UserId = user.Id,
            Name = user.Name,
            Email = user.Email,
        };
    }
}
