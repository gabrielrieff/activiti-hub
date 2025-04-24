using ActivityHub.Domain.Entities;

namespace ActivityHub.Domain.Services.LoggedUser;
public interface ILoggedUser
{
    Task<User> Get();
}
