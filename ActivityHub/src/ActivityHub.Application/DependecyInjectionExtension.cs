
using ActivityHub.Application.UseCase.Activities.Delete;
using ActivityHub.Application.UseCase.Activities.GetById;
using ActivityHub.Application.UseCase.Activities.ListMonth;
using ActivityHub.Application.UseCase.Activities.Register;
using ActivityHub.Application.UseCase.Activities.UpdateStatus;
using ActivityHub.Application.UseCase.Activities.UpdateText;
using ActivityHub.Application.UseCase.Auth;
using ActivityHub.Application.UseCase.Users.GetProfile;
using ActivityHub.Application.UseCase.Users.UpdateProfile;
using Microsoft.Extensions.DependencyInjection;

namespace ActivityHub.Application
{
    public static class DependecyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection service)
        {
            AddUseCase(service);
        }

        private static void AddUseCase(IServiceCollection service)
        {
            service.AddScoped<IAuthenticatedWithGithubUseCase, AuthenticatedWithGithubUseCase>();

            //User
            service.AddScoped<IGetProfileUseCase, GetProfileUseCase>();
            service.AddScoped<IUpdateProfileUser, UpdateProfileUser>();

            //Activity
            service.AddScoped<IRegisterActivityUseCase, RegisterActivityUseCase>();
            service.AddScoped<IDeleteActivityUseCase, DeleteActivityUseCase>();
            service.AddScoped<IGetActivityByIdUseCase, GetActivityByIdUseCase>();
            service.AddScoped<IActivitiesListMonthUseCase, ActivitiesListMonthUseCase>();
            service.AddScoped<IActivityUpdateStatusUseCase, ActivityUpdateStatusUseCase>();
            service.AddScoped<IActivityUpdateTextUseCase, ActivityUpdateTextUseCase>();
        }
    }
}
