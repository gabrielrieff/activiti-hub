using Bogus;
using NotificationService.API.Models.Request;

namespace NotificationService.Tests.Models.Request;
public class RegisterNotificationRequestBuilder
{
    public static RegisterNotificationRequest Build()
    {
        return new Faker<RegisterNotificationRequest>()
            .RuleFor(n => n.Message, faker => faker.Commerce.ProductName())
            .RuleFor(n => n.RecipientEmail, faker => faker.Internet.Email())
            .RuleFor(n => n.RecipientUserId, _ => 1);
    }
}
