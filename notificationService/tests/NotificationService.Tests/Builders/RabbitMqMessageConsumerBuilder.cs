using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using NotificationService.API;

namespace NotificationService.Tests.Builders;
public class RabbitMqMessageConsumerBuilder
{
    public RabbitMqMessageConsumer Build()
    {
        var _serviceProviderMock = new Mock<IServiceProvider>();
        var _loggerMock = new Mock<ILogger<RabbitMqMessageConsumer>>();
        var _configurationMock = new Mock<IConfiguration>();

        return new RabbitMqMessageConsumer(
                _serviceProviderMock.Object,
                _loggerMock.Object,
                _configurationMock.Object
        );
    }
}
