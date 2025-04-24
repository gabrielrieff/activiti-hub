using ActivityHub.Domain.Entities;
using ActivityHub.Domain.Repositories.AccountProviders;
using Microsoft.EntityFrameworkCore;

namespace ActivityHub.Infrastructure.DataAccess.Repositories.AccountProviders
{
    public class AccountProvidersReadOnlyRepository : IAccountProvidersReadOnlyRepository, IAccountProviderWhiteOnlyRepository
    {
        private readonly ActivityHubDbContext _dbContext;
        public AccountProvidersReadOnlyRepository(ActivityHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(AccountProvider accountProvider)
        {
            await _dbContext.AccountProviders.AddAsync(accountProvider);
        }

        public async Task<AccountProvider?> GetAccountProviderByUserId(int userId)
        {
            return await _dbContext.AccountProviders
                .AsNoTracking()
                .FirstOrDefaultAsync(provider => provider.UserId == userId);
        }
    }
}
