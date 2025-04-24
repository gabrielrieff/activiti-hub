using MongoDB.Driver;
using NotificationService.API.Models.Entity;
using NotificationService.API.Repositories;

namespace NotificationService.API.Services;

public class MongoNotificationRepository : INotificationRepository
{
    private readonly IMongoCollection<Notification> _collection;

    public MongoNotificationRepository(IConfiguration config)
    {
        var client = new MongoClient(config["Mongo:ConnectionString"]);
        var database = client.GetDatabase(config["Mongo:Database"]);
        _collection = database.GetCollection<Notification>("notifications");
    }

    public async Task<IList<Notification>> GetByUserId(int userId)
    {
        return await _collection.Find(x => x.RecipientUserId == userId).ToListAsync();
    }

    public async Task<Notification> GetNotificationById(string id)
    {
       return await _collection.Find(x => x.ID == id).FirstOrDefaultAsync();
    }

    public async Task MarkAsRead(string id, int userId)
    {
        var update = Builders<Notification>.Update.Set(x => x.IsRead, true);
        await _collection.UpdateOneAsync(x => x.ID == id && x.RecipientUserId == userId, update);
    }

    public async Task<Notification> Register(Notification notification)
    {
        await _collection.InsertOneAsync(notification);
        return notification;
    }
}
