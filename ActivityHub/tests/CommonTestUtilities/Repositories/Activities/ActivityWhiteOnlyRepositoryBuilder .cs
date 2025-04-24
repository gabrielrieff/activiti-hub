using ActivityHub.Domain.Repositories.Activities;
using Moq;

namespace CommonTestUtilities.Repositories.Activities;
public class ActivityWhiteOnlyRepositoryBuilder
{
    private readonly Mock<IActivityWhiteOnlyRepository> _repository;

    public ActivityWhiteOnlyRepositoryBuilder()
    {
        _repository = new Mock<IActivityWhiteOnlyRepository>();
    }

    public IActivityWhiteOnlyRepository Build() => _repository.Object;
}
