using ActivityHub.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ActivityHub.Infrastructure.Migrations;
public static class DataBaseMigration
{
    public static async Task MigrateDataBase(IServiceProvider serviceProvider)
    {
        var dbContext = serviceProvider.GetRequiredService<ActivityHubDbContext>();

        await dbContext.Database.MigrateAsync();
    }
}
