using Moq;
using NotificationService.API.Repositories;

namespace NotificationService.Tests.Repositories;
public class RabbitMqConnectionBuilder
{
    private readonly Mock<IRabbitMqConnection> _rabbitMqConnection;

    public RabbitMqConnectionBuilder()
    {
        _rabbitMqConnection = new Mock<IRabbitMqConnection>();
    }

    public IRabbitMqConnection Build() => _rabbitMqConnection.Object;
}
