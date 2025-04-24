using RabbitMQ.Client;
using static MongoDB.Driver.WriteConcern;

namespace NotificationService.API.Repositories;

public interface IRabbitMqConnection : IDisposable
{
    Task<IConnection> CreateConnectionAsync(CancellationToken cancellationToken);
    Task<IChannel> CreateChannelAsync(CancellationToken cancellationToken);
}
