using ActivityHub.Application.UseCase.Activities.GetById;
using ActivityHub.Communication.Enums;
using ActivityHub.Domain.Entities;
using CommonTestUtilities.Entities;
using CommonTestUtilities.Repositories.Activities;
using FluentAssertions;

namespace UseCases.Test.Activities.GetById;
public class GetActivityByIdUseCaseTest
{

    [Fact]
    public async void Sucess()
    {
        var user = UserBuilder.Build();
        var activity = ActivityBuilder.Build(user);
        var useCase = CreateUseCase(activity);
        var result = await useCase.Execute(activity.Id);

        result.Should().NotBeNull();
        result.Id.Should().BeGreaterThan(0);
        result.Title.Should().Be(activity.Title);
        result.Description.Should().Be(activity.Description);
        result.Status.Should().Be((ActivityStatus)activity.Status);
    }

    private GetActivityByIdUseCase CreateUseCase(Activity activity)
    {
        var activityReadOnlyRepo = new ActivityReadOnlyRepositoryBuilder().GetById(activity).Build();

        return new GetActivityByIdUseCase(activityReadOnlyRepo);
    }
}
