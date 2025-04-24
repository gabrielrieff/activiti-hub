using Newtonsoft.Json;
using NotificationService.API.Application.UseCase.Register;
using NotificationService.API.Models.Request;
using NotificationService.API.Repositories;

namespace NotificationService.API.Services.RabbitMQ;

public class MessageProcessor : IMessageProcessor
{
    private readonly IServiceProvider _serviceProvider;

    public MessageProcessor(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task ProcessMessageAsync(string message)
    {
        var payload = JsonConvert.DeserializeObject<RegisterNotificationRequest>(message);

        using (var scope = _serviceProvider.CreateScope())
        {
            var dispatcher = scope.ServiceProvider.GetRequiredService<INotificationDispatcherRepository>();
            var repository = scope.ServiceProvider.GetRequiredService<IRegisterNotificationUseCase>();
            var notification = await repository.Execute(payload);

            await dispatcher.SendNotificationAsync(notification.RecipientUserId.ToString(), notification);
        }
    }
}
