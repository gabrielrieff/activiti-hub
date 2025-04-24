using ActivityHub.Domain.Entities;

namespace ActivityHub.Domain.Repositories.Activities;
public interface IActivityWhiteOnlyRepository
{
    Task Add(Activity activity);

    Task Delete(Activity activity);

    Task Update(Activity activity);
}
