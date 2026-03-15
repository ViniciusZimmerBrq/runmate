namespace RunMate.Application.Auth.Dtos;

public sealed record RegisterResponse(
    Guid UserId,
    string Name,
    string Email);
