using ActivityHub.Domain.Entities;

namespace ActivityHub.Domain.Security.Tokens;
public interface IAccessTokenGenerator
{
    string Generate(User user);
}
