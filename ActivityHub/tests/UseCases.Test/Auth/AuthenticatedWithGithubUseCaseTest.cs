using ActivityHub.Application.UseCase.Auth;
using ActivityHub.Domain.Entities;
using CommonTestUtilities.Entities;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Repositories.Users;
using CommonTestUtilities.Request.Authenticated;
using CommonTestUtilities.Token;
using FluentAssertions;

namespace UseCases.Test.Auth;
public class AuthenticatedWithGithubUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        var user = UserBuilder.Build();
        var code = RequestAuthenticatedWithGithubBuilder.Build();
        var httpClient = HttpClientBuilder.Build();
        var useCase = CreateUseCase(user, httpClient);

        var result = await useCase.Execute(code);

        result.Should().NotBeNull();
        result.token.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task Should_ThrowException_When_GithubApiReturnsError()
    {
        var user = UserBuilder.Build();
        var code = RequestAuthenticatedWithGithubBuilder.Build();
        var httpClient = HttpClientBuilder.BuildError();
        var useCase = CreateUseCase(user, httpClient);

        Func<Task> act = async () => await useCase.Execute(code);

        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("Failed to deserialize the response. Ensure the response is in the expected format.");
    }

    private AuthenticatedWithGithubUseCase CreateUseCase(User user, HttpClient httpClient)
    {
        var unitOfWork = UnitOfWorkBuilder.Build();
        var userWhiteOnlyBuilder = UserWhiteOnlyRepositoryBuilder.Build();
        var userReadOnlyBuilder = UserReadOnlyRepositoryBuilder.Build();
        var accountProvidersReadOnlyBuilder = AccountProvidersReadOnlyRepositoryBuilder.Build();
        var accountProvidersWhiteOnlyBuilder = AccountProvidersWhiteOnlyRepositoryBuilder.Build();
        var jwtToken = JwtTokenGeneratorBuilder.Build();

        return new AuthenticatedWithGithubUseCase(
            httpClient: httpClient,
            userWhiteOnlyRepository: userWhiteOnlyBuilder, 
            userReadOnlyRepository: userReadOnlyBuilder, 
            accountProvidersReadOnlyRepository: accountProvidersReadOnlyBuilder,
            accountProvidersWhiteOnlyRepository: accountProvidersWhiteOnlyBuilder,
            accessTokenGenerator: jwtToken,
            unitOfWork: unitOfWork);
    }
}
