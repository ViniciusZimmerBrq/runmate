using RunMate.Application.Auth.Interfaces;
using RunMate.Application.Auth.Validators;
using RunMate.Application.Exceptions;
using RunMate.Domain.Entities;
using RunMate.Domain.Repositories;

namespace RunMate.Application.Auth.Commands;

public sealed class RegisterUserCommand
{
    public required string Name { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
}

public sealed class RegisterUserResult
{
    public Guid UserId { get; init; }
    public required string Name { get; init; }
    public required string Email { get; init; }
}

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
        RegisterUserCommand command,
        CancellationToken cancellationToken = default)
    {
        var validationErrors = RegisterRequestValidator.Validate(command.Name, command.Email, command.Password);
        if (validationErrors.Count > 0)
            throw new ValidationException(validationErrors);

        var alreadyExists = await _userRepository.ExistsByEmailAsync(command.Email, cancellationToken);
        if (alreadyExists)
            throw new EmailAlreadyInUseException(command.Email);

        var passwordHash = _passwordHashService.HashPassword(command.Password);
        var user = new User(Guid.NewGuid(), command.Name, command.Email, passwordHash);

        await _userRepository.AddAsync(user, cancellationToken);

        return new RegisterUserResult
        {
            UserId = user.Id,
            Name = user.Name,
            Email = user.Email,
        };
    }
}
