using ActivityHub.Communication.Request.User;

namespace ActivityHub.Application.UseCase.Users.UpdateProfile;
public interface IUpdateProfileUser
{
    Task Execute(RequestUpdateProfileJson request);
}
