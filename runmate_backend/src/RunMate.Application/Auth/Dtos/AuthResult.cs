namespace RunMate.Application.Auth.Dtos;

public sealed record AuthResult(
    string AccessToken,
    int ExpiresInSeconds,
    Guid UserId,
    string Name,
    string Email);
