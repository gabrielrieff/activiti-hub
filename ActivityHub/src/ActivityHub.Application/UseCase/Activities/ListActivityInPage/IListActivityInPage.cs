using ActivityHub.Communication.Response.Activities;

namespace ActivityHub.Application.UseCase.Activities.ListActivityInPage;
public interface IListActivityInPage
{
    Task<ResponseActivitiesInPageSize> Execute(int month, int year, int page, int size);
}
