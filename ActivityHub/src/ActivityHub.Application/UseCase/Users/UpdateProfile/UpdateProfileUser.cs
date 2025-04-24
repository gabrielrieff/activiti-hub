using ActivityHub.Communication.Request.User;
using ActivityHub.Domain.Repositories;
using ActivityHub.Domain.Repositories.Users;
using ActivityHub.Domain.Services.LoggedUser;
using ActivityHub.Exception.ExceptionBase;

namespace ActivityHub.Application.UseCase.Users.UpdateProfile;
public class UpdateProfileUser : IUpdateProfileUser
{
    private readonly ILoggedUser _loggedUser;
    private readonly IUserWhiteOnlyRepository _userWhiteOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateProfileUser(ILoggedUser loggedUser, IUserWhiteOnlyRepository userWhiteOnlyRepository, IUnitOfWork unitOfWork)
    {
        _loggedUser = loggedUser;
        _userWhiteOnlyRepository = userWhiteOnlyRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(RequestUpdateProfileJson request)
    {
        Validator(request);

        var user = await _loggedUser.Get();

        user.Name = request.Name;
        user.UpdateAt = DateTime.Now;

        _userWhiteOnlyRepository.Update(user);

        await _unitOfWork.Commit();
    }

    private void Validator(RequestUpdateProfileJson request)
    {
        if (string.IsNullOrEmpty(request.Name))
        {
            throw new ErrorOnValidationException(["Nome é requerido!"]);
        }
    }
}
