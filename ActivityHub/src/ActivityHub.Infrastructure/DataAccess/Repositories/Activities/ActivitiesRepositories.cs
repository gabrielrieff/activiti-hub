using ActivityHub.Domain.Entities;
using ActivityHub.Domain.Enums;
using ActivityHub.Domain.Repositories.Activities;
using Microsoft.EntityFrameworkCore;

namespace ActivityHub.Infrastructure.DataAccess.Repositories.Activities;
public class ActivitiesRepositories : IActivityWhiteOnlyRepository, IActivityReadOnlyRepository
{
    private readonly ActivityHubDbContext _dbContext;

    public ActivitiesRepositories(ActivityHubDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Activity activity)
    {
        await _dbContext.Activities.AddAsync(activity);
    }

    public async Task Delete(Activity activity)
    {
        _dbContext.Activities.Remove(activity);
    }

    public async Task<Activity?> GetById(int id)
    {
        return await _dbContext.Activities.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<Activity?> GetByIdAndUser(int id, User user)
    {
        return _dbContext.Activities
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id && x.UserId == user.Id);
    }

    public async Task<List<Activity>> GetByMonthAndYear(int month, int year, User user)
    {
        var startDate = new DateTime(year, month, 1);
        var endDate = startDate.AddMonths(1).AddSeconds(-1);

        return await _dbContext.Activities
            .AsNoTracking()
            .Where(act => act.CreatedAt.Month == month && act.CreatedAt.Year == year && act.UserId == user.Id)
            .OrderBy(a => a.CreatedAt)
            .ToListAsync();
    }

    public async Task Update(Activity activity)
    {
         _dbContext.Activities.Update(activity);
    }
}
