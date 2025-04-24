namespace ActivityHub.Domain.Security.Tokens;
public interface ITokenProvider
{
    string TokenOnRequest();
}
