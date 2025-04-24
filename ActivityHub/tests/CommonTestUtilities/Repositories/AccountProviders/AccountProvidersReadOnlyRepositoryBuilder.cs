using ActivityHub.Domain.Repositories.AccountProviders;
using Moq;

namespace CommonTestUtilities.Repositories.Users;
public class AccountProvidersReadOnlyRepositoryBuilder
{
    public static IAccountProvidersReadOnlyRepository Build()
    {
        var mock = new Mock<IAccountProvidersReadOnlyRepository>();
        return mock.Object;
    }
}
