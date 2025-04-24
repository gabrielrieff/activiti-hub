using ActivityHub.Domain.Repositories.Users;
using ActivityHub.Domain.Repositories;
using ActivityHub.Infrastructure.DataAccess;
using ActivityHub.Infrastructure.DataAccess.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ActivityHub.Domain.Repositories.AccountProviders;
using ActivityHub.Infrastructure.DataAccess.Repositories.AccountProviders;
using ActivityHub.Domain.Security.Tokens;
using ActivityHub.Infrastructure.Security.Tokens;
using ActivityHub.Domain.Services.LoggedUser;
using ActivityHub.Infrastructure.Services.LoggedUser;
using ActivityHub.Infrastructure.DataAccess.Repositories.Activities;
using ActivityHub.Domain.Repositories.Activities;
using ActivityHub.Domain.Services.EventPublisher;
using ActivityHub.Infrastructure.Services.EventPublisher;

namespace ActivityHub.Infrastructure
{
    public static class DependencyInjectionExtension
    {

        public static void AddInfraestruture(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ILoggedUser, LoggedUser>();
            services.AddScoped<IEventPublisher, EventPublisherRabbitMQ>();

            AddRepositories(services);
            AddToken(services, configuration);
            AddDbContext(services, configuration);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //User
            services.AddScoped<IUserWhiteOnlyRepository, UserRepositories>();
            services.AddScoped<IUserReadOnlyRepository, UserRepositories>();

            //account provider
            services.AddScoped<IAccountProvidersReadOnlyRepository, AccountProvidersReadOnlyRepository>();
            services.AddScoped<IAccountProviderWhiteOnlyRepository, AccountProvidersReadOnlyRepository>();

            //activity
            services.AddScoped<IActivityWhiteOnlyRepository, ActivitiesRepositories>();
            services.AddScoped<IActivityReadOnlyRepository, ActivitiesRepositories>();

        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ActivityHubDbContext>(config => config.UseNpgsql(connectionString));

        }

        private static void AddToken(IServiceCollection services, IConfiguration configuration)
        {
            var expirationTimeMinutor = configuration.GetValue<uint>("Settings:Jwt:ExpirationMinutes");
            var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

            services.AddScoped<IAccessTokenGenerator>(config => new JwtTokenGenerator(expirationTimeMinutor, signingKey!));
        }
    }
}
