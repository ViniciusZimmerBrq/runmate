namespace RunMate.Application.Exceptions;

public sealed class EmailAlreadyInUseException : Exception
{
    public EmailAlreadyInUseException(string email)
        : base($"The email address is already registered.")
    {
    }
}
