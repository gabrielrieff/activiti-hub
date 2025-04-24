using System.Text;
using ActivityHub.Domain.Services.EventPublisher;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace ActivityHub.Infrastructure.Services.EventPublisher;
internal class EventPublisherRabbitMQ : IEventPublisher
{

    private readonly ConnectionFactory _factory;

    public EventPublisherRabbitMQ(IConfiguration configuration)
    {
        _factory = new ConnectionFactory
        {
            Uri = new Uri(configuration.GetConnectionString("RabbitMq")!),
        };
    }

    public async Task PublishAsync(string queueName, string message)
    {
        await using var connection = await _factory.CreateConnectionAsync();
        await using var channel = await connection.CreateChannelAsync();

        await channel.QueueDeclareAsync(queueName, durable: true, exclusive: false, autoDelete: false);

        var body = Encoding.UTF8.GetBytes(message);

        await channel.BasicPublishAsync("", queueName, body: body);
    }
}
