using ActivityHub.Domain.Entities;

namespace ActivityHub.Domain.Repositories.AccountProviders
{
    public interface IAccountProviderWhiteOnlyRepository
    {
        Task Add(AccountProvider accountProvider);

    }
}
