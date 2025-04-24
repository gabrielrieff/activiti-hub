using ActivityHub.Domain.Entities;
using ActivityHub.Domain.Repositories.Activities;
using Moq;

namespace CommonTestUtilities.Repositories.Activities;
public class ActivityReadOnlyRepositoryBuilder
{
    private readonly Mock<IActivityReadOnlyRepository> _repo;
    public ActivityReadOnlyRepositoryBuilder()
    {
        _repo = new Mock<IActivityReadOnlyRepository>();       
    }

    public IActivityReadOnlyRepository Build() => _repo.Object;


    public ActivityReadOnlyRepositoryBuilder GetById(Activity activity)
    {
        _repo.Setup(config => config.GetById(It.IsAny<int>())).ReturnsAsync(activity);

        return this;
    }


    public ActivityReadOnlyRepositoryBuilder GetByMonthAndYear(List<Activity> activities)
    {
        _repo.Setup(config => config.GetByMonthAndYear(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<User>())).ReturnsAsync(activities);

        return this;
    }
}
