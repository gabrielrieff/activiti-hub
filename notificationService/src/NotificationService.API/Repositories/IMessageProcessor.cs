namespace NotificationService.API.Repositories;

public interface IMessageProcessor
{
    Task ProcessMessageAsync(string message);
}
