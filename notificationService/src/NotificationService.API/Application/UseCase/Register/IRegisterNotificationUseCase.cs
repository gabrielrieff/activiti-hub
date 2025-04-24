using NotificationService.API.Models.Entity;
using NotificationService.API.Models.Request;

namespace NotificationService.API.Application.UseCase.Register;

public interface IRegisterNotificationUseCase
{
    Task<Notification> Execute(RegisterNotificationRequest request);
}
