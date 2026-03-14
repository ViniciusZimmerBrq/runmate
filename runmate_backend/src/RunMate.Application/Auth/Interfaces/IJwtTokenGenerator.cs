namespace RunMate.Application.Auth.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid userId, string email, string name);
}
