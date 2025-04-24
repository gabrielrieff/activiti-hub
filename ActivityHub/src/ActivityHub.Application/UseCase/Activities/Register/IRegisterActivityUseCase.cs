using ActivityHub.Communication.Request.Activities;
using ActivityHub.Communication.Response.Activities;

namespace ActivityHub.Application.UseCase.Activities.Register;
public interface IRegisterActivityUseCase
{
    Task<ResponseRegisterActivityJson> Execute(RequestRegisterActityJson request);
}
