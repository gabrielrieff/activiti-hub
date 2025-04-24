namespace ActivityHub.Domain.Entities;
public class Notification
{
    public string ID { get; set; } = string.Empty;
    public int RecipientUserId { get; set; }
    public string RecipientEmail { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public bool IsRead { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
