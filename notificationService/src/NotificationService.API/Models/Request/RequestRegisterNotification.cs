namespace NotificationService.API.Models.Request;

public class RequestRegisterNotification
{
    public int RecipientUserId { get; set; }
    public string RecipientEmail { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}
