using ActivityHub.Domain.Entities;
using ActivityHub.Domain.Repositories.Users;
using Microsoft.EntityFrameworkCore;

namespace ActivityHub.Infrastructure.DataAccess.Repositories.Users
{
    internal class UserRepositories : IUserWhiteOnlyRepository, IUserReadOnlyRepository
    {
        private readonly ActivityHubDbContext _dbContext;

        public UserRepositories(ActivityHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(User user)
        {
            await _dbContext.Users.AddAsync(user);
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user.Email == email);
        }

        public void Update(User user)
        {
            _dbContext.Users.Update(user);
        }
    }
}
