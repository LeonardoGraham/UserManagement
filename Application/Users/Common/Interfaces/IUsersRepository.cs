using Domain.Users;

namespace Application.Users.Common.Interfaces;

public interface IUsersRepository
{
    Task AddUserAsync(User user, CancellationToken cancellationToken);
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}