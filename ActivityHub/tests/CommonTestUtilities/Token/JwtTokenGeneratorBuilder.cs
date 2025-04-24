using ActivityHub.Domain.Entities;
using ActivityHub.Domain.Security.Tokens;
using Moq;

namespace CommonTestUtilities.Token;
public class JwtTokenGeneratorBuilder
{
    public static IAccessTokenGenerator Build()
    {
        var mock = new Mock<IAccessTokenGenerator>();
        mock.Setup(tokenGenerator => tokenGenerator.Generate(It.IsAny<User>())).Returns("token");

        return mock.Object;

    }
}
