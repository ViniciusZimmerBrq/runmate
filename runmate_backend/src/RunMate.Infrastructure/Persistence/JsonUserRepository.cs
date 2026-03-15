using System.Text.Json;
using RunMate.Application.Auth.Interfaces;
using RunMate.Domain.Entities;

namespace RunMate.Infrastructure.Persistence;

public sealed class JsonUserRepository : IUserRepository
{
    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true,
    };

    private static readonly SemaphoreSlim Mutex = new(1, 1);

    private readonly string _storagePath;

    public JsonUserRepository(FileUserStoreOptions options)
    {
        _storagePath = options.Path;
    }

    public async Task<bool> TryAddAsync(User user, CancellationToken cancellationToken)
    {
        await Mutex.WaitAsync(cancellationToken);

        try
        {
            var users = await LoadUsersAsync(cancellationToken);
            if (users.Any(existing =>
                    string.Equals(existing.NormalizedEmail, user.NormalizedEmail, StringComparison.Ordinal)))
            {
                return false;
            }

            users.Add(new StoredUserRecord(
                Id: user.Id,
                Name: user.Name,
                Email: user.Email,
                NormalizedEmail: user.NormalizedEmail,
                PasswordHash: user.PasswordHash,
                CreatedAtUtc: user.CreatedAtUtc));

            await SaveUsersAsync(users, cancellationToken);
            return true;
        }
        finally
        {
            Mutex.Release();
        }
    }

    private async Task<List<StoredUserRecord>> LoadUsersAsync(CancellationToken cancellationToken)
    {
        if (!File.Exists(_storagePath))
        {
            return [];
        }

        await using var stream = File.OpenRead(_storagePath);
        var users = await JsonSerializer.DeserializeAsync<List<StoredUserRecord>>(
            stream,
            SerializerOptions,
            cancellationToken);

        return users ?? [];
    }

    private async Task SaveUsersAsync(
        IReadOnlyCollection<StoredUserRecord> users,
        CancellationToken cancellationToken)
    {
        var directory = Path.GetDirectoryName(_storagePath);
        if (!string.IsNullOrWhiteSpace(directory))
        {
            Directory.CreateDirectory(directory);
        }

        await using var stream = File.Create(_storagePath);
        await JsonSerializer.SerializeAsync(stream, users, SerializerOptions, cancellationToken);
    }

    private sealed record StoredUserRecord(
        Guid Id,
        string Name,
        string Email,
        string NormalizedEmail,
        string PasswordHash,
        DateTimeOffset CreatedAtUtc);
}
