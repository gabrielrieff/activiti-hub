using ActivityHub.Communication.Request.Activities;

namespace ActivityHub.Application.UseCase.Activities.UpdateText;
public interface IActivityUpdateTextUseCase
{
    Task Execute(int id, RequestUpdateText request);
}
