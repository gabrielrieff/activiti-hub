using ActivityHub.Domain.Repositories;

namespace ActivityHub.Infrastructure.DataAccess
{
    internal class UnitOfWork : IUnitOfWork
    {

        public ActivityHubDbContext _dbContext;

        public UnitOfWork(ActivityHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit() => await _dbContext.SaveChangesAsync();
    }
}
