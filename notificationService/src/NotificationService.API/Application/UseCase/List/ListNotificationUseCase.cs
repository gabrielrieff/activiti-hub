using NotificationService.API.Models.Entity;
using NotificationService.API.Repositories;

namespace NotificationService.API.Application.UseCase.List;

public class ListNotificationUseCase : IListNotificationUseCase
{
    private readonly INotificationRepository _repository;

    public ListNotificationUseCase(INotificationRepository repository)
    {
        _repository = repository;
    }

    public async Task<IList<Notification>> Execute(int userId)
    {
        var response = await _repository.GetByUserId(userId);

        return response;
    }
}
