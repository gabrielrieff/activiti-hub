
using ActivityHub.Domain.Repositories;
using ActivityHub.Domain.Repositories.Activities;
using ActivityHub.Domain.Services.LoggedUser;
using ActivityHub.Exception.ExceptionBase;

namespace ActivityHub.Application.UseCase.Activities.Delete;
public class DeleteActivityUseCase : IDeleteActivityUseCase
{
    private readonly IActivityWhiteOnlyRepository _activityWhiteOnlyRepository;
    private readonly IActivityReadOnlyRepository _activitiesReadOnlyRepository;
    private readonly ILoggedUser _loggedUser;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteActivityUseCase(
        IActivityWhiteOnlyRepository activityWhiteOnlyRepository,
        IActivityReadOnlyRepository activitiesReadOnlyRepository,
        ILoggedUser loggedUser,
        IUnitOfWork unitOfWork)
    {
        _activityWhiteOnlyRepository = activityWhiteOnlyRepository;
        _activitiesReadOnlyRepository = activitiesReadOnlyRepository;
        _loggedUser = loggedUser;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(int id)
    {
        var user = await _loggedUser.Get();

        var activity = await _activitiesReadOnlyRepository.GetByIdAndUser(id, user);

        if(activity is null)
        {
            throw new NotFoundException("Atividade não encontrada.");
        }

        await _activityWhiteOnlyRepository.Delete(activity);

        await _unitOfWork.Commit();
    }
}
