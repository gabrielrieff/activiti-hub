using ActivityHub.Communication.Request.Authenticated;
using Bogus;

namespace CommonTestUtilities.Request.Authenticated;
public class RequestAuthenticatedWithGithubBuilder
{
    public static RequestAuthenticatedWithGithub Build()
    {
        return new Faker<RequestAuthenticatedWithGithub>()
            .RuleFor(x => x.Code, f => f.Internet.UserNameUnicode());
    }
}
