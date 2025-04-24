using ActivityHub.Communication.Request.Activities;
using Bogus;

namespace CommonTestUtilities.Request.Activities;
public class RequestUpdateTextBuilder
{
    public RequestUpdateText Build()
    {
        return new Faker<RequestUpdateText>()
            .RuleFor(x => x.Title, f => f.Lorem.Sentence())
            .RuleFor(x => x.Description, f => f.Lorem.Paragraph(2));
    }
}
