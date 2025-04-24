using System.Text;
using NotificationService.API.Repositories;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace NotificationService.API;

public class RabbitMqMessageConsumer : BackgroundService, INotificationConsumer
{
    private readonly IRabbitMqConnection _rabbitMqConnection;
    private readonly IMessageProcessor _messageProcessor;

    public RabbitMqMessageConsumer(
        IRabbitMqConnection rabbitMqConnection,
        IMessageProcessor messageProcessor)
    {
        _rabbitMqConnection = rabbitMqConnection;
        _messageProcessor = messageProcessor;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var connection = await _rabbitMqConnection.CreateConnectionAsync(stoppingToken);
        var channel = await _rabbitMqConnection.CreateChannelAsync(stoppingToken);

        await channel.QueueDeclareAsync(
            queue: "task-status-updated",
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null,
            cancellationToken: stoppingToken);

        var consumer = new AsyncEventingBasicConsumer(channel);

        consumer.ReceivedAsync += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);


            try
            {
                await _messageProcessor.ProcessMessageAsync(message);
                await channel.BasicAckAsync(deliveryTag: ea.DeliveryTag, multiple: false);
            }
            catch (Exception ex)
            {
            }

        };

        await channel.BasicConsumeAsync(queue: "task-status-updated", autoAck: false, consumer: consumer);
        await Task.Delay(Timeout.Infinite, stoppingToken);
    }

    public override void Dispose()
    {
        _rabbitMqConnection.Dispose();
        base.Dispose();
    }
}