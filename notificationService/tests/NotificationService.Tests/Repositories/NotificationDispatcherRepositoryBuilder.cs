using Moq;
using NotificationService.API.Repositories;

namespace NotificationService.Tests.Repositories;
public class NotificationDispatcherRepositoryBuilder
{
    private readonly Mock<INotificationDispatcherRepository> _repo;

    public NotificationDispatcherRepositoryBuilder()
    {
        _repo = new Mock<INotificationDispatcherRepository>();
    }

    public INotificationDispatcherRepository Build() => _repo.Object;
}
