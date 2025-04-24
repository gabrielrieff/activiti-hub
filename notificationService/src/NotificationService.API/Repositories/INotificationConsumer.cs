namespace NotificationService.API.Repositories;

public interface INotificationConsumer
{
    Task StartAsync(CancellationToken cancellationToken);
}
