using ActivityHub.Communication.Request.Activities;

namespace ActivityHub.Application.UseCase.Activities.UpdateStatus;
public interface IActivityUpdateStatusUseCase
{
    Task Execute(int id, RequestUpdateStatusActivityJson request);
}
