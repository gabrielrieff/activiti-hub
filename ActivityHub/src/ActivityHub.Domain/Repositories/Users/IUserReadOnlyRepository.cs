using ActivityHub.Domain.Entities;

namespace ActivityHub.Domain.Repositories.Users;
public interface IUserReadOnlyRepository
{
    Task<User?> GetUserByEmail(string email);
}
