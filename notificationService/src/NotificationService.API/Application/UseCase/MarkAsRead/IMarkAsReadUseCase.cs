namespace NotificationService.API.Application.UseCase.MarkAsReadUseCase;

public interface IMarkAsReadUseCase
{
    Task Execute(string notificationId, int userId);
}
