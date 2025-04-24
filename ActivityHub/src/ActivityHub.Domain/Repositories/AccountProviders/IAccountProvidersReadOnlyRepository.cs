using ActivityHub.Domain.Entities;

namespace ActivityHub.Domain.Repositories.AccountProviders
{
    public interface IAccountProvidersReadOnlyRepository
    {
        Task<AccountProvider?> GetAccountProviderByUserId(int userID);
    }
}
