using NotificationService.API.Models.Entity;

namespace NotificationService.API.Application.UseCase.List;

public interface IListNotificationUseCase
{
    Task<IList<Notification>> Execute(int userId);
}
