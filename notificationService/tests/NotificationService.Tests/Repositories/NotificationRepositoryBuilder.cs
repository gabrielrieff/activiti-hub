using Moq;
using NotificationService.API.Models.Entity;
using NotificationService.API.Repositories;

namespace NotificationService.Tests.Repositories;
public class NotificationRepositoryBuilder
{
    private readonly Mock<INotificationRepository> _repo;

    public NotificationRepositoryBuilder()
    {
        _repo = new Mock<INotificationRepository>();
    }

    public NotificationRepositoryBuilder GetByUserId(Notification notification)
    {
        _repo.Setup(r => r.GetNotificationById(notification.ID)).ReturnsAsync(notification);
        return this;
    }
    
    public NotificationRepositoryBuilder Register(Notification notification)
    {
        _repo.Setup(r => r.Register(notification)).ReturnsAsync(notification);
        return this;
    }

    public INotificationRepository Build() => _repo.Object;
}
