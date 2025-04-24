using Moq;
using NotificationService.API.Repositories;

namespace NotificationService.Tests.Repositories;
public class MessageProcessorBuilder
{
    private readonly Mock<IMessageProcessor> _msgProcess;

    public MessageProcessorBuilder()
    {
        _msgProcess = new Mock<IMessageProcessor>();
    }

    public IMessageProcessor Build() => _msgProcess.Object;
}
