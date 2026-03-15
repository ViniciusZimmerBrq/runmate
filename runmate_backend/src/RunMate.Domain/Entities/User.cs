namespace RunMate.Domain.Entities;

public sealed class User
{
    public Guid Id { get; init; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string NormalizedEmail { get; private set; }
    public string PasswordHash { get; private set; }
    public DateTimeOffset CreatedAtUtc { get; private set; }

    public User(
        Guid id,
        string name,
        string email,
        string normalizedEmail,
        string passwordHash,
        DateTimeOffset createdAtUtc)
    {
        Id = id;
        Name = name;
        Email = email;
        NormalizedEmail = normalizedEmail;
        PasswordHash = passwordHash;
        CreatedAtUtc = createdAtUtc;
    }
}
