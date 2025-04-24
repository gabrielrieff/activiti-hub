using System.Text.Json;
using ActivityHub.Communication.Request.Activities;
using ActivityHub.Domain.Entities;
using ActivityHub.Domain.Repositories;
using ActivityHub.Domain.Repositories.Activities;
using ActivityHub.Domain.Services.EventPublisher;
using ActivityHub.Domain.Services.LoggedUser;
using ActivityHub.Exception.ExceptionBase;

namespace ActivityHub.Application.UseCase.Activities.UpdateStatus;
public class ActivityUpdateStatusUseCase : IActivityUpdateStatusUseCase
{
    private readonly ILoggedUser _loggedUser;
    private readonly IActivityWhiteOnlyRepository _activityWhiteOnlyRepository;
    private readonly IActivityReadOnlyRepository _activityReadOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEventPublisher _eventPublisher;

    public ActivityUpdateStatusUseCase(
        ILoggedUser loggedUser,
        IActivityWhiteOnlyRepository activityWhiteOnlyRepository,
        IActivityReadOnlyRepository activityReadOnlyRepository,
        IUnitOfWork unitOfWork,
        IEventPublisher eventPublisher)
    {
        _loggedUser = loggedUser;
        _activityWhiteOnlyRepository = activityWhiteOnlyRepository;
        _activityReadOnlyRepository = activityReadOnlyRepository;
        _unitOfWork = unitOfWork;
        _eventPublisher = eventPublisher;
    }

    public async Task Execute(int id, RequestUpdateStatusActivityJson request)
    {
        var user = await _loggedUser.Get();

        var activity = await _activityReadOnlyRepository.GetByIdAndUser(id, user);

        if(activity is null)
        {
            throw new NotFoundException("Atividade não existe");
        }

        activity.Status = (Domain.Enums.ActivityStatus)request.Status;
        activity.UpdateAt = DateTime.Now;

        _activityWhiteOnlyRepository.Update(activity);

        var notification = new Notification
        {
            RecipientUserId = user.Id,
            RecipientEmail = user.Email,
            Message = $"A atividade {activity.Title} foi atualizada para o status {activity.Status}",
        };

        var json = JsonSerializer.Serialize(notification);

        await _eventPublisher.PublishAsync("task-status-updated", json);

        await _unitOfWork.Commit();
    }
}
