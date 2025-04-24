using Bogus;
using NotificationService.API.Models.Entity;

namespace NotificationService.Tests.Models.Entity;
public class NotificationBuilder
{
    public static Notification Build()
    {
        return new Faker<Notification>()
            .RuleFor(n => n.ID, _ => "not-003")
            .RuleFor(n => n.Message, faker => faker.Commerce.ProductName())
            .RuleFor(n => n.RecipientEmail, faker => faker.Internet.Email())
            .RuleFor(n => n.RecipientUserId, _ => 1);
    }
}
