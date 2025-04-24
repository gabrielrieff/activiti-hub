using ActivityHub.Communication.Enums;
using ActivityHub.Communication.Response.Activities;
using ActivityHub.Domain.Repositories.Activities;
using ActivityHub.Domain.Services.LoggedUser;

namespace ActivityHub.Application.UseCase.Activities.ListMonth;
public class ActivitiesListMonthUseCase : IActivitiesListMonthUseCase
{
    private readonly ILoggedUser _loggedUser;
    private readonly IActivityReadOnlyRepository _activitiesReadOnlyRepository;
    public ActivitiesListMonthUseCase(
        ILoggedUser loggedUser,
        IActivityReadOnlyRepository activitiesReadOnlyRepository)
    {
        _loggedUser = loggedUser;
        _activitiesReadOnlyRepository = activitiesReadOnlyRepository;
    }

    public async Task<List<ResponseActivitiesListJson>> Execute(int month, int year)
    {
        var user = await _loggedUser.Get();

        var activities = await _activitiesReadOnlyRepository.GetByMonthAndYear(month, year, user);

        var groupedActivities = Enum.GetValues(typeof(ActivityStatus))
        .Cast<ActivityStatus>()
        .ToDictionary(status => status, status => new List<ResponseActivityJson>());

        foreach (var activity in activities)
        {
            groupedActivities[(ActivityStatus)activity.Status].Add(
                new ResponseActivityJson { 
                    Id = activity.Id,
                    Description = activity.Description,
                    Status = (ActivityStatus)activity.Status,
                    Title = activity.Title
                });
        }

        var result = groupedActivities
                    .Select(g => new ResponseActivitiesListJson
                    {
                        Id = Guid.NewGuid(), // Identificador único para o grupo
                        Title = g.Key.ToString(), // Nome do status
                        ListActivities = g.Value // Lista de atividades associadas ao status
                    })
                    .OrderBy(ob => ob.Title)
                    .ToList();

        return result;
    }
}