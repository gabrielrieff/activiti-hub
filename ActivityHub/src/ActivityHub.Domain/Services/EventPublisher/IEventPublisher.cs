namespace ActivityHub.Domain.Services.EventPublisher;
public interface IEventPublisher
{
    Task PublishAsync(string queueName, string message);
}
