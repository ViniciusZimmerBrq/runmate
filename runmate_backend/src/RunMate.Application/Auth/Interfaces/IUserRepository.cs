using RunMate.Domain.Entities;

namespace RunMate.Application.Auth.Interfaces;

public interface IUserRepository
{
    Task<bool> TryAddAsync(User user, CancellationToken cancellationToken);
}
