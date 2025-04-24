using NotificationService.API.Application.UseCase.List;
using NotificationService.API.Application.UseCase.MarkAsReadUseCase;
using NotificationService.API.Application.UseCase.Register;

namespace NotificationService.API.Application;

public static class DependecyInjectionExtension
{
    public static void AddApplication(this IServiceCollection service)
    {
        service.AddScoped<IRegisterNotificationUseCase, RegisterNotificationUseCase>();
        service.AddScoped<IListNotificationUseCase, ListNotificationUseCase>();
        service.AddScoped<IMarkAsReadUseCase, MarkAsReadUseCase>();
    }
}
