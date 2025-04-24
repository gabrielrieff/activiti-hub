using Microsoft.AspNetCore.SignalR;
using NotificationService.API.Application.UseCase.List;
using NotificationService.API.Application.UseCase.MarkAsReadUseCase;

namespace NotificationService.API.Hubs;

public class NotificationHub : Hub
{
    private readonly IListNotificationUseCase _listNotificationuseCase;
    private readonly IMarkAsReadUseCase _markAsReadUseCase;
    public NotificationHub(IListNotificationUseCase listNotificationuseCase, IMarkAsReadUseCase markAsReadUseCase)
    {
        _listNotificationuseCase = listNotificationuseCase;
        _markAsReadUseCase = markAsReadUseCase;
    }

    public override async Task OnConnectedAsync()
    {
        var userID = Context.GetHttpContext()?.Request.Query["userId"];

        if (!string.IsNullOrEmpty(userID))
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userID);
            Console.WriteLine($"Usuário {userID} adicionado ao grupo {userID}.");

            var notifications = await _listNotificationuseCase.Execute(int.Parse(userID));
            
            await Clients.Group(userID).SendAsync("ReceiveListNotification", notifications);
        }

        await base.OnConnectedAsync();
    }

    public async Task MarkAsReadNotification(string notificationId)
    {
        var userId = Context.UserIdentifier;
        if (userId == null) return;

        await _markAsReadUseCase.Execute(notificationId, int.Parse(userId));
    }
}
