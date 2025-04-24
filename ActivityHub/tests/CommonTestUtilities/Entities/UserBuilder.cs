using ActivityHub.Domain.Entities;
using Bogus;

namespace CommonTestUtilities.Entities;
public class UserBuilder
{
    public static User Build()
    {
        return new Faker<User>()
            .RuleFor(u => u.Id, _ => 1)
            .RuleFor(u => u.Name, faker => faker.Person.FullName)
            .RuleFor(u => u.Email, faker => faker.Internet.Email())
            .RuleFor(u => u.passwordHash, (_, user) => "123")
            .RuleFor(u => u.avatarUrl, faker => faker.Internet.Avatar())
            .RuleFor(u => u.UserIdentifier, _ => Guid.NewGuid());
    }
}
