using ActivityHub.Domain.Repositories.Users;
using Moq;

namespace CommonTestUtilities.Repositories.Users;
public class UserWhiteOnlyRepositoryBuilder
{
    public static IUserWhiteOnlyRepository Build()
    {
        var mock = new Mock<IUserWhiteOnlyRepository>();
        return mock.Object;
    }
}
