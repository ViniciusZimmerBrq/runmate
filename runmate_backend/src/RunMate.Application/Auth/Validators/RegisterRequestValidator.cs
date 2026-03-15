using System.Net.Mail;
using RunMate.Application.Auth.Dtos;

namespace RunMate.Application.Auth.Validators;

public static class RegisterRequestValidator
{
    public static Dictionary<string, string[]> Validate(RegisterRequest request)
    {
        var errors = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

        if (string.IsNullOrWhiteSpace(request.Name))
        {
            AddError(errors, nameof(request.Name), "Name is required.");
        }

        if (string.IsNullOrWhiteSpace(request.Email))
        {
            AddError(errors, nameof(request.Email), "Email is required.");
        }
        else if (!IsValidEmail(request.Email))
        {
            AddError(errors, nameof(request.Email), "Email format is invalid.");
        }

        if (string.IsNullOrWhiteSpace(request.Password))
        {
            AddError(errors, nameof(request.Password), "Password is required.");
        }
        else
        {
            if (request.Password.Length < 8)
            {
                AddError(errors, nameof(request.Password), "Password must be at least 8 characters long.");
            }

            if (!request.Password.Any(char.IsUpper))
            {
                AddError(errors, nameof(request.Password), "Password must contain at least one uppercase letter.");
            }

            if (!request.Password.Any(char.IsLower))
            {
                AddError(errors, nameof(request.Password), "Password must contain at least one lowercase letter.");
            }

            if (!request.Password.Any(char.IsDigit))
            {
                AddError(errors, nameof(request.Password), "Password must contain at least one number.");
            }

            if (!request.Password.Any(IsSpecialCharacter))
            {
                AddError(errors, nameof(request.Password), "Password must contain at least one special character.");
            }
        }

        return errors.ToDictionary(
            pair => pair.Key,
            pair => pair.Value.ToArray(),
            StringComparer.OrdinalIgnoreCase);
    }

    private static void AddError(
        IDictionary<string, List<string>> errors,
        string key,
        string message)
    {
        if (!errors.TryGetValue(key, out var messages))
        {
            messages = new List<string>();
            errors[key] = messages;
        }

        messages.Add(message);
    }

    private static bool IsValidEmail(string email)
    {
        try
        {
            _ = new MailAddress(email);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }

    private static bool IsSpecialCharacter(char character) =>
        !char.IsLetterOrDigit(character) && !char.IsWhiteSpace(character);
}
