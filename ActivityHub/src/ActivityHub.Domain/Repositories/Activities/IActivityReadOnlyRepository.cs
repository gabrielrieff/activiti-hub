using ActivityHub.Domain.Entities;

namespace ActivityHub.Domain.Repositories.Activities;
public interface IActivityReadOnlyRepository
{
    Task<Activity?> GetById(int id);
    Task<Activity?> GetByIdAndUser(int id, User user);
    Task<List<Activity>> GetByMonthAndYear(int month, int year, User user);

}
