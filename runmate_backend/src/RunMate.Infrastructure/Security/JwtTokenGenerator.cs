using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RunMate.Application.Auth.Interfaces;

namespace RunMate.Infrastructure.Security;

public sealed class JwtTokenGenerator : IJwtTokenGenerator
{
    private const int DefaultExpirationMinutes = 60;

    private readonly JwtOptions _options;

    public JwtTokenGenerator(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }

    public (string Token, int ExpiresInSeconds) GenerateToken(Guid userId, string email, string name)
    {
        var secretBytes = Encoding.UTF8.GetBytes(_options.Secret);
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(secretBytes),
            SecurityAlgorithms.HmacSha256);

        var expirationMinutes = _options.ExpirationMinutes > 0
            ? _options.ExpirationMinutes
            : DefaultExpirationMinutes;

        var expiresAt = DateTime.UtcNow.AddMinutes(expirationMinutes);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(JwtRegisteredClaimNames.Name, name),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var token = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: expiresAt,
            signingCredentials: signingCredentials);

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        var expiresInSeconds = (int)(expiresAt - DateTime.UtcNow).TotalSeconds;

        return (tokenString, expiresInSeconds);
    }
}
