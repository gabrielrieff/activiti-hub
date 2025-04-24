using NotificationService.API.Models.Entity;

namespace NotificationService.API.Repositories;

public interface INotificationRepository
{
    Task<IList<Notification>> GetByUserId(int userId);
    Task<Notification> GetNotificationById(string id);
    Task<Notification> Register(Notification notification);
    Task MarkAsRead(string id, int userId);
}
