
using ActivityHub.Communication.Response.Activities;
using ActivityHub.Domain.Repositories.Activities;
using ActivityHub.Exception.ExceptionBase;

namespace ActivityHub.Application.UseCase.Activities.GetById;
public class GetActivityByIdUseCase : IGetActivityByIdUseCase
{
    private readonly IActivityReadOnlyRepository _activitiesReadOnlyRepository;

    public GetActivityByIdUseCase(
        IActivityReadOnlyRepository activitiesReadOnlyRepository)
    {
        _activitiesReadOnlyRepository = activitiesReadOnlyRepository;
    }

    public async Task<ResponseActivityJson> Execute(int id)
    {
        var activity = await _activitiesReadOnlyRepository.GetById(id);

        if(activity is null)
        {
            throw new NotFoundException("Atividade não existe");
        }

        return new ResponseActivityJson
        {
            Id = activity.Id,
            Title = activity.Title,
            Description = activity.Description,
            Status = (Communication.Enums.ActivityStatus)activity.Status,
        };

    }
}
