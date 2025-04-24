using ActivityHub.Communication.Request.Activities;
using ActivityHub.Communication.Response.Activities;
using ActivityHub.Domain.Entities;
using ActivityHub.Domain.Repositories;
using ActivityHub.Domain.Repositories.Activities;
using ActivityHub.Domain.Services.LoggedUser;
using ActivityHub.Exception.ExceptionBase;

namespace ActivityHub.Application.UseCase.Activities.Register;
public class RegisterActivityUseCase : IRegisterActivityUseCase
{
    private readonly ILoggedUser _loggedUser;
    private readonly IActivityWhiteOnlyRepository _acitivityWhiteOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterActivityUseCase(
        ILoggedUser loggedUser, 
        IActivityWhiteOnlyRepository acitivityWhiteOnlyRepository,
        IUnitOfWork unitOfWork)
    {
        _loggedUser = loggedUser;
        _acitivityWhiteOnlyRepository = acitivityWhiteOnlyRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseRegisterActivityJson> Execute(RequestRegisterActityJson request)
    {
        Validator(request);

        var user = await _loggedUser.Get();

        var acticity = new Activity
        {
            Title = request.Title,
            Description = request.Description,
            UserId = user.Id
        };

        await _acitivityWhiteOnlyRepository.Add(acticity);

        await _unitOfWork.Commit();

        return new ResponseRegisterActivityJson
        {
            Title = acticity.Title,
            Description = acticity.Description
        };
    }

    private void Validator(RequestRegisterActityJson request)
    {
        List<string> messageError = [];
        if (string.IsNullOrEmpty(request.Title))
        {
            messageError.Add("Title is required");
        }
        
        if (string.IsNullOrEmpty(request.Description))
        {
            messageError.Add("Description is required");
        }

        if(messageError.Count != 0)
        {
            throw new ErrorOnValidationException(messageError);
        }
    }
}
