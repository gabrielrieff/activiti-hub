using ActivityHub.Communication.Request.Activities;
using ActivityHub.Domain.Repositories;
using ActivityHub.Domain.Repositories.Activities;
using ActivityHub.Domain.Services.LoggedUser;
using ActivityHub.Exception.ExceptionBase;

namespace ActivityHub.Application.UseCase.Activities.UpdateText;
public class ActivityUpdateTextUseCase : IActivityUpdateTextUseCase
{
    private readonly ILoggedUser _loggedUser;
    private readonly IActivityReadOnlyRepository _activityReadOnlyRepository;
    private readonly IActivityWhiteOnlyRepository _activityWhiteOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ActivityUpdateTextUseCase(
        ILoggedUser loggedUser,
        IActivityReadOnlyRepository activityReadOnlyRepository,
        IActivityWhiteOnlyRepository activityWhiteOnlyRepository,
        IUnitOfWork unitOfWork)
    {
        _loggedUser = loggedUser;
        _activityReadOnlyRepository = activityReadOnlyRepository;
        _activityWhiteOnlyRepository = activityWhiteOnlyRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(int id, RequestUpdateText request)
    {
        Validator(request);

        var user = await _loggedUser.Get();

        var activity = await _activityReadOnlyRepository.GetByIdAndUser(id, user);

        if (activity is null)
        {
            throw new NotFoundException("Atividade não existe");
        }

        activity.Title = request.Title;
        activity.Description = request.Description;
        activity.UpdateAt = DateTime.Now;

        _activityWhiteOnlyRepository.Update(activity);

        await _unitOfWork.Commit();
    }

    private void Validator(RequestUpdateText request)
    {
        List<string> errors = [];

        if (string.IsNullOrWhiteSpace(request.Title))
        {
            errors.Add("O título é obrigatório");
        }

        if (string.IsNullOrWhiteSpace(request.Description))
        {
            errors.Add("A descrição é obrigatória");
        }

        if (errors.Count > 0)
        {
            throw new ErrorOnValidationException(errors);
        }

    }
}
