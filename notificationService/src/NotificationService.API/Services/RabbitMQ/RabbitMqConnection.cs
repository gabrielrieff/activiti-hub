using NotificationService.API.Repositories;
using RabbitMQ.Client;

namespace NotificationService.API.Services.RabbitMQ;

public class RabbitMqConnection : IRabbitMqConnection
{
    private readonly ConnectionFactory _factory;
    private IConnection? _connection;

    public RabbitMqConnection(IConfiguration configuration)
    {
        _factory = new ConnectionFactory
        {
            Uri = new Uri(configuration["RabbitMQ:ConnectionString"])
        };
    }

    public async Task<IChannel> CreateChannelAsync(CancellationToken cancellationToken)
    {
        if (_connection == null)
        {
            throw new InvalidOperationException("Connection has not been established. Call CreateConnectionAsync first.");
        }

        return await Task.Run(() => _connection.CreateChannelAsync(), cancellationToken);
    }

    public async Task<IConnection> CreateConnectionAsync(CancellationToken cancellationToken)
    {
        _connection = await Task.Run(() => _factory.CreateConnectionAsync(), cancellationToken);
        return _connection;
    }

    public void Dispose()
    {
        _connection?.Dispose();
    }
}
