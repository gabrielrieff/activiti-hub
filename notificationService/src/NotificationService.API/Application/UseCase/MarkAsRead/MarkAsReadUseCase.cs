
using NotificationService.API.Repositories;

namespace NotificationService.API.Application.UseCase.MarkAsReadUseCase;

public class MarkAsReadUseCase: IMarkAsReadUseCase
{
    private readonly INotificationRepository _repository;
    public MarkAsReadUseCase(INotificationRepository repository)
    {
        _repository = repository;
    }

    public async Task Execute(string notificationId, int userId)
    {
        if(string.IsNullOrEmpty(notificationId) || userId <= 0)
        {
            throw new Exception();
        }

        await _repository.MarkAsRead(notificationId, userId);
    }
}
