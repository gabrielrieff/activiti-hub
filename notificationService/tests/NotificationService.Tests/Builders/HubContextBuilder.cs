using Microsoft.AspNetCore.SignalR;
using Moq;
using NotificationService.API.Hubs;

namespace NotificationService.Tests.Builders;
public class HubContextBuilder
{
    private readonly Mock<IHubContext<NotificationHub>> _hubContextMock = new();
    private readonly Mock<IHubClients> _clientsMock = new();
    private readonly Mock<IClientProxy> _groupMock = new();

    public HubContextBuilder()
    {
        _clientsMock.Setup(x => x.Group(It.IsAny<string>())).Returns(_groupMock.Object);
        _hubContextMock.Setup(x => x.Clients).Returns(_clientsMock.Object);
    }

    public Mock<IClientProxy> GroupMock => _groupMock;
    public IHubContext<NotificationHub> Build() => _hubContextMock.Object;
}
