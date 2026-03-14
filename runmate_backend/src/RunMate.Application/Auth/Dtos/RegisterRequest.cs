namespace RunMate.Application.Auth.Dtos;

public sealed record RegisterRequest(
    string Name,
    string Email,
    string Password);
