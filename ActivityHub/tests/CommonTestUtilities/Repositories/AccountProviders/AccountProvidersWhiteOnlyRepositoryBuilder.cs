using ActivityHub.Domain.Repositories.AccountProviders;
using Moq;

namespace CommonTestUtilities.Repositories.Users;
public class AccountProvidersWhiteOnlyRepositoryBuilder
{
    public static IAccountProviderWhiteOnlyRepository Build()
    {
        var mock = new Mock<IAccountProviderWhiteOnlyRepository>();
        return mock.Object;
    }
}
