using ActivityHub.Domain.Entities;
using ActivityHub.Domain.Enums;
using Bogus;

namespace CommonTestUtilities.Entities;
public class ActivityBuilder
{

    public static List<Activity> Colletion(User user, uint count = 3)
    {
        var list = new List<Activity>();

        var activityId = 1;
        for (int i = 0; i < count; i++)
        {
            var activity = Build(user);
            activity.Id = activityId++;

            list.Add(activity);
        }

        return list;

    }

    public static Activity Build(User user)
    {
        return new Faker<Activity>()
            .RuleFor(act => act.Id, _ => 1)
            .RuleFor(act => act.Title, faker => faker.Lorem.Text())
            .RuleFor(act => act.Description, faker => faker.Lorem.Paragraph())
            .RuleFor(act => act.UserId, _ => user.Id)
            .RuleFor(act => act.Status, faker => faker.PickRandom<ActivityStatus>());
    }
}
