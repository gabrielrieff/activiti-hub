using ActivityHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ActivityHub.Infrastructure.DataAccess;

public class ActivityHubDbContext : DbContext
{
    public ActivityHubDbContext(DbContextOptions<ActivityHubDbContext> options) : base(options) { }
    public DbSet<AccountProvider> AccountProviders { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Activity> Activities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}

public class ActivityHubDbContextFactory : IDesignTimeDbContextFactory<ActivityHubDbContext>
{
    public ActivityHubDbContext CreateDbContext(string[] args)
    {
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "ActivityHub.Api");

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<ActivityHubDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        builder.UseNpgsql(connectionString);

        return new ActivityHubDbContext(builder.Options);
    }
}


