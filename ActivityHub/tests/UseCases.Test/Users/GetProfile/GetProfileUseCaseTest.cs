using ActivityHub.Application.UseCase.Users.GetProfile;
using ActivityHub.Domain.Entities;
using CommonTestUtilities.Entities;
using CommonTestUtilities.Services.LoggedUser;
using FluentAssertions;

namespace UseCases.Test.Users.GetProfile;
public class GetProfileUseCaseTest
{
    [Fact]
    public async Task Sucess()
    {
        var user = UserBuilder.Build();
        var useCase = CreateUseCase(user);

        var result = await useCase.Execute();

        result.Should().NotBeNull();
        result.Name.Should().Be(user.Name);
        result.Email.Should().Be(user.Email);
        result.Avatar_url.Should().Be(user.avatarUrl);
        result.CreatedAt.Should().Be(user.CreatedAt);
    }

    private GetProfileUseCase CreateUseCase(User user)
    {
        var loggedUser = LoggedUserBuilder.Build(user);

        return new GetProfileUseCase(loggedUser);
    }
}
