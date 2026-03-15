using RunMate.Application.Auth.Dtos;
using RunMate.Application.Auth.Interfaces;
using RunMate.Domain.Entities;

namespace RunMate.Application.Auth.Commands;

public sealed class RegisterUserCommandHandler
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHashService _passwordHashService;

    public RegisterUserCommandHandler(
        IUserRepository userRepository,
        IPasswordHashService passwordHashService)
    {
        _userRepository = userRepository;
        _passwordHashService = passwordHashService;
    }

    public async Task<RegisterUserResult> HandleAsync(
        RegisterRequest request,
        CancellationToken cancellationToken)
    {
        var user = new User(
            id: Guid.NewGuid(),
            name: request.Name.Trim(),
            email: SanitizeEmail(request.Email),
            normalizedEmail: NormalizeEmail(request.Email),
            passwordHash: _passwordHashService.HashPassword(request.Password),
            createdAtUtc: DateTimeOffset.UtcNow);

        var added = await _userRepository.TryAddAsync(user, cancellationToken);
        if (!added)
        {
            return new RegisterUserResult(User: null, EmailAlreadyExists: true);
        }

        return new RegisterUserResult(
            User: new RegisterResponse(
                UserId: user.Id,
                Name: user.Name,
                Email: user.Email),
            EmailAlreadyExists: false);
    }

    private static string NormalizeEmail(string email) =>
        email.Trim().ToUpperInvariant();

    private static string SanitizeEmail(string email) =>
        email.Trim().ToLowerInvariant();
}
