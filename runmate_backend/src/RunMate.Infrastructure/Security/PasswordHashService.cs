using Microsoft.AspNetCore.Identity;
using RunMate.Application.Auth.Interfaces;

namespace RunMate.Infrastructure.Security;

/// <summary>
/// Uses ASP.NET Core Identity's PasswordHasher which applies PBKDF2 with HMAC-SHA512,
/// 128-bit salt, 256-bit subkey, and 100,000 iterations by default (Identity v3 format).
/// Passwords are never stored in plain text.
/// </summary>
public sealed class PasswordHashService : IPasswordHashService
{
    private readonly PasswordHasher<object> _hasher = new();

    public string HashPassword(string password)
    {
        return _hasher.HashPassword(null!, password);
    }

    public bool VerifyPassword(string hashedPassword, string providedPassword)
    {
        var result = _hasher.VerifyHashedPassword(null!, hashedPassword, providedPassword);
        return result != PasswordVerificationResult.Failed;
    }
}
