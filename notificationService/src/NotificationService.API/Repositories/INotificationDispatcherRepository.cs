using NotificationService.API.Models.Entity;

namespace NotificationService.API.Repositories;

public interface INotificationDispatcherRepository
{
    Task SendNotificationAsync(string userId, Notification notification);
}
