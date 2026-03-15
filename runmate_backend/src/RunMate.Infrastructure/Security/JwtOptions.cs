namespace RunMate.Infrastructure.Security;

/// <summary>
/// Strongly-typed options for JWT configuration.
/// Populated from appsettings section "Jwt" / env vars JWT__*.
/// Secret must never be hardcoded or committed to source control.
/// </summary>
public sealed class JwtOptions
{
    public const string SectionName = "Jwt";

    public string Secret { get; init; } = string.Empty;
    public string Issuer { get; init; } = string.Empty;
    public string Audience { get; init; } = string.Empty;

    /// <summary>Token lifetime in minutes. Defaults to 60 if not set.</summary>
    public int ExpirationMinutes { get; init; } = 60;
}
