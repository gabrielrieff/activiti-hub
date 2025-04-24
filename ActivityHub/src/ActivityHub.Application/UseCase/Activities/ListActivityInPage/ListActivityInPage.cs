
using ActivityHub.Communication.Response.Activities;

namespace ActivityHub.Application.UseCase.Activities.ListActivityInPage;
public class ListActivityInPage : IListActivityInPage
{
    public ListActivityInPage()
    {
        
    }

    public Task<ResponseActivitiesInPageSize> Execute(int month, int year, int page, int size)
    {
        throw new NotImplementedException();
    }
}
