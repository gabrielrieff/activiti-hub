using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace NotificationService.API.Models.Entity;

public class Notification
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("_id")]
    public string ID { get; set; } = string.Empty;
    [BsonElement("recipientUserId")]
    public int RecipientUserId { get; set; }
    [BsonElement("recipientEmail")]
    public string RecipientEmail { get; set; } = string.Empty;
    [BsonElement("message")]
    public string Message { get; set; } = string.Empty;
    [BsonElement("isRead")]
    public bool IsRead { get; set; } = false;
    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
