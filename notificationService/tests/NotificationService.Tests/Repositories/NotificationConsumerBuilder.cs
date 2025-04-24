using Moq;
using NotificationService.API.Repositories;

namespace NotificationService.Tests.Repositories;
public class NotificationConsumerBuilder
{
    private readonly Mock<INotificationConsumer> _repo;

    public NotificationConsumerBuilder()
    {
        _repo = new Mock<INotificationConsumer>();
    }

    public INotificationConsumer Build() => _repo.Object;
}
