using NotificationService.API.Models.Entity;
using NotificationService.API.Models.Request;
using NotificationService.API.Repositories;

namespace NotificationService.API.Application.UseCase.Register;

public class RegisterNotificationUseCase : IRegisterNotificationUseCase
{
    private readonly INotificationRepository _repository;

    public RegisterNotificationUseCase(INotificationRepository repository)
    {
        _repository = repository;
    }

    public async Task<Notification> Execute(RegisterNotificationRequest request)
    {
        var notification = new Notification
        {
            RecipientUserId = request.RecipientUserId,
            RecipientEmail = request.RecipientEmail,
            Message = request.Message,
        };

        await _repository.Register(notification);

        return notification;
    }

    private void Validate(RegisterNotificationRequest request)
    {

    }
}
