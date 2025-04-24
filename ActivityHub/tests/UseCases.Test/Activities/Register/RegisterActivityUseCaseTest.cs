using ActivityHub.Application.UseCase.Activities.Register;
using ActivityHub.Domain.Entities;
using ActivityHub.Exception.ExceptionBase;
using CommonTestUtilities.Entities;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Repositories.Activities;
using CommonTestUtilities.Request.Activities;
using CommonTestUtilities.Services.LoggedUser;
using FluentAssertions;

namespace UseCases.Test.Activities.Register;
public class RegisterActivityUseCaseTest
{

    [Fact]
    public async void Sucess()
    {
        var user = UserBuilder.Build();
        var request = new RequestRegisterActityJsonBuilder().Build();
        var useCase = CreateUseCase(user);

        var response = await useCase.Execute(request);
        response.Should().NotBeNull();
        response.Title.Should().Be(request.Title);
        response.Description.Should().Be(request.Description);
    }

    [Fact]
    public async void Error_Title_Empty()
    {
        var user = UserBuilder.Build();
        var request = new RequestRegisterActityJsonBuilder().Build();
        request.Title = string.Empty;
        var useCase = CreateUseCase(user);

        var act = async () => await useCase.Execute(request);

        var result = await act.Should().ThrowAsync<ErrorOnValidationException>();
        result.Where(ex => ex.GetErrors().Count == 1 &&
                     ex.GetErrors().Contains("Title is required"));
    }
    
    [Fact]
    public async void Error_Description_Empty()
    {
        var user = UserBuilder.Build();
        var request = new RequestRegisterActityJsonBuilder().Build();
        request.Description = string.Empty;
        var useCase = CreateUseCase(user);

        var act = async () => await useCase.Execute(request);

        var result = await act.Should().ThrowAsync<ErrorOnValidationException>();
        result.Where(ex => ex.GetErrors().Count == 1 &&
                     ex.GetErrors().Contains("Description is required"));
    }

    private RegisterActivityUseCase CreateUseCase(User user)
    {
        var unitOfWork = UnitOfWorkBuilder.Build();
        var loggedUser = LoggedUserBuilder.Build(user);
        var activityWhitedOnlyRepo = new ActivityWhiteOnlyRepositoryBuilder().Build();

        return new RegisterActivityUseCase(
            loggedUser: loggedUser,
            acitivityWhiteOnlyRepository: activityWhitedOnlyRepo,
            unitOfWork: unitOfWork);
    }
}
