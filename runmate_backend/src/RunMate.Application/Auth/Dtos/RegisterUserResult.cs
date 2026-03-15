namespace RunMate.Application.Auth.Dtos;

public sealed record RegisterUserResult(
    RegisterResponse? User,
    bool EmailAlreadyExists);
