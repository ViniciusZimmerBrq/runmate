using System.Collections.Concurrent;
using RunMate.Domain.Entities;
using RunMate.Domain.Repositories;

namespace RunMate.Infrastructure.Persistence;

/// <summary>
/// Thread-safe in-memory repository for development and testing.
/// Replace with EF Core implementation before production.
/// </summary>
public sealed class InMemoryUserRepository : IUserRepository
{
    private readonly ConcurrentDictionary<string, User> _store = new(StringComparer.OrdinalIgnoreCase);

    public Task<User?> FindByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        _store.TryGetValue(email, out var user);
        return Task.FromResult(user);
    }

    public Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_store.ContainsKey(email));
    }

    public Task AddAsync(User user, CancellationToken cancellationToken = default)
    {
        if (!_store.TryAdd(user.Email, user))
            throw new InvalidOperationException($"A user with email '{user.Email}' already exists.");

        return Task.CompletedTask;
    }
}
