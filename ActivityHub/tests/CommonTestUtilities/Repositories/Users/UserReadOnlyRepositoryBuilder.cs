using ActivityHub.Domain.Repositories.Users;
using Moq;

namespace CommonTestUtilities.Repositories.Users;
public class UserReadOnlyRepositoryBuilder
{
    public static IUserReadOnlyRepository Build()
    {
        var mock = new Mock<IUserReadOnlyRepository>();
        return mock.Object;
    }
}
