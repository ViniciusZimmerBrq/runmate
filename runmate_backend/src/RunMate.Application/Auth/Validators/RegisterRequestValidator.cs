using System.Text.RegularExpressions;

namespace RunMate.Application.Auth.Validators;

public static class RegisterRequestValidator
{
    private static readonly Regex EmailRegex = new(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public static IReadOnlyList<string> Validate(string name, string email, string password)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(name))
            errors.Add("Name is required.");
        else if (name.Trim().Length < 2)
            errors.Add("Name must be at least 2 characters.");
        else if (name.Trim().Length > 100)
            errors.Add("Name must not exceed 100 characters.");

        if (string.IsNullOrWhiteSpace(email))
            errors.Add("Email is required.");
        else if (!EmailRegex.IsMatch(email))
            errors.Add("Email format is invalid.");
        else if (email.Length > 254)
            errors.Add("Email must not exceed 254 characters.");

        errors.AddRange(PasswordPolicyValidator.Validate(password));

        return errors.AsReadOnly();
    }
}
