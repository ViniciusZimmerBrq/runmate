namespace RunMate.Application.Auth.Validators;

public sealed class EmailAlreadyInUseException : Exception
{
    public string Email { get; }

    public EmailAlreadyInUseException(string email)
        : base($"The email address is already registered.")
    {
        Email = email;
    }
}
