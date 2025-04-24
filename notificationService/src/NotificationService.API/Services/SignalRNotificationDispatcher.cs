using Microsoft.AspNetCore.SignalR;
using NotificationService.API.Hubs;
using NotificationService.API.Models.Entity;
using NotificationService.API.Repositories;

namespace NotificationService.API.Services;

public class SignalRNotificationDispatcher : INotificationDispatcherRepository
{
    private readonly IHubContext<NotificationHub> _hubContext;
    public SignalRNotificationDispatcher(IHubContext<NotificationHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task SendNotificationAsync(string userId, Notification notification)
    {
        if (string.IsNullOrEmpty(userId))
        {
            throw new Exception("UserID not informated");
        }

        if (notification == null)
        {
            throw new Exception("Notification not informated");
        }

        await _hubContext.Clients.Group(userId).SendAsync("ReceiveNotification", notification);
        Console.WriteLine($"Enviando notificação para {userId}: {notification}");
    }
}
