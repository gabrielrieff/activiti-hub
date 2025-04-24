using ActivityHub.Communication.Response.Activities;

namespace ActivityHub.Application.UseCase.Activities.ListMonth;
public interface IActivitiesListMonthUseCase
{
    Task<List<ResponseActivitiesListJson>> Execute(int month, int year);
}
