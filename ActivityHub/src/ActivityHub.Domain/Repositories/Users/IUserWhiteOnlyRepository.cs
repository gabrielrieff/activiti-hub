using ActivityHub.Domain.Entities;

namespace ActivityHub.Domain.Repositories.Users
{
    public interface IUserWhiteOnlyRepository
    {
        Task Add(User user);

        void Update(User user);
    }
}
