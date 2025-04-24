using ActivityHub.Communication.Request.Authenticated;
using ActivityHub.Communication.Response.Authenticated;

namespace ActivityHub.Application.UseCase.Auth
{
    public interface IAuthenticatedWithGithubUseCase
    {
        Task<ResponseRegisteredUserJson> Execute(RequestAuthenticatedWithGithub response);
    }
}
