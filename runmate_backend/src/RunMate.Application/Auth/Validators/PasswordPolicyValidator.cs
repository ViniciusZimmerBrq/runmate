namespace RunMate.Application.Auth.Validators;

/// <summary>
/// Enforces the password policy: 8+ chars, uppercase, lowercase, digit, special character.
/// </summary>
public static class PasswordPolicyValidator
{
    private const int MinLength = 8;
    private const string SpecialCharacters = "!@#$%^&*()_+-=[]{}|;':\",./<>?";

    public static IReadOnlyList<string> Validate(string? password)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(password))
        {
            errors.Add("Password is required.");
            return errors.AsReadOnly();
        }

        if (password.Length < MinLength)
            errors.Add($"Password must be at least {MinLength} characters.");

        if (!password.Any(char.IsUpper))
            errors.Add("Password must contain at least one uppercase letter.");

        if (!password.Any(char.IsLower))
            errors.Add("Password must contain at least one lowercase letter.");

        if (!password.Any(char.IsDigit))
            errors.Add("Password must contain at least one number.");

        if (!password.Any(c => SpecialCharacters.Contains(c)))
            errors.Add("Password must contain at least one special character (!@#$%^&*...).");

        return errors.AsReadOnly();
    }
}
