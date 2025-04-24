using ActivityHub.Communication.Response.Users;

namespace ActivityHub.Application.UseCase.Users.GetProfile
{
    public interface IGetProfileUseCase
    {
        Task<ResponseUserProfileJson> Execute();
    }
}
