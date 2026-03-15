namespace RunMate.Application.Auth.Interfaces;

public interface IJwtTokenGenerator
{
    /// <summary>
    /// Generates a signed JWT token for the given user identity.
    /// Returns the token string and its expiration in seconds from now.
    /// </summary>
    (string Token, int ExpiresInSeconds) GenerateToken(Guid userId, string email, string name);
}
