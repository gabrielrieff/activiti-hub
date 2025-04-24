using FluentAssertions;
using Moq;
using NotificationService.API.Services;
using NotificationService.Tests.Builders;
using NotificationService.Tests.Models.Entity;

namespace NotificationService.Tests.Services;
public class SignalRNotificationDispatcherTests
{

    [Fact]
    public async Task Sucess_SignalRNotificationDispatcher()
    {
        var hubBuilder = new HubContextBuilder();
        var dispatcher = new SignalRNotificationDispatcher(hubBuilder.Build());

        var userId = "123";
        var notification = NotificationBuilder.Build();

        await dispatcher.SendNotificationAsync(userId, notification);

        hubBuilder.GroupMock.Verify(x => x.SendCoreAsync(
            "ReceiveNotification",
            It.Is<object[]>(args => args[0] == notification),
            default
        ), Times.Once);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task Error_SignalRNotificationDispatcher_WhenUserIdIsNullOrEmpty(string userId)
    {
        var hubBuilder = new HubContextBuilder();
        var dispatcher = new SignalRNotificationDispatcher(hubBuilder.Build());

        var notification = NotificationBuilder.Build();

        var exception = await Record.ExceptionAsync(() =>
         dispatcher.SendNotificationAsync(userId, notification));

        exception.Should().BeOfType<Exception>();
        exception?.Message.Should().Be("UserID not informated");
    }

    [Fact]
    public async Task Error_SignalRNotificationDispatcher_WhenNotificationIsNull()
    {
        var hubBuilder = new HubContextBuilder();
        var dispatcher = new SignalRNotificationDispatcher(hubBuilder.Build());

        var userId = "1";

        var exception = await Record.ExceptionAsync(() =>
         dispatcher.SendNotificationAsync(userId, null!));

        exception.Should().BeOfType<Exception>();
        exception?.Message.Should().Be("Notification not informated");
    }
}
