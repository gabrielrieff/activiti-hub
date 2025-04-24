using ActivityHub.Communication.Response.Activities;

namespace ActivityHub.Application.UseCase.Activities.GetById;
public interface IGetActivityByIdUseCase
{
    Task<ResponseActivityJson> Execute(int id);  
}
