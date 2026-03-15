namespace RunMate.Application.Dtos;

public sealed record RegisterRequestDto(
    string Name,
    string Email,
    string Password);

public sealed record LoginRequestDto(
    string Email,
    string Password);

public sealed record AuthResponseDto(
    string AccessToken,
    int ExpiresInSeconds,
    string UserName);
