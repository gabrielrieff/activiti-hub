using System.Net;

namespace ActivityHub.Exception.ExceptionBase;
public class InvalidLoginExpection : ActivityHubException
{
    public InvalidLoginExpection() : base("E-mail ou senha invalidos.") { }

    public override int StatusCode => (int)HttpStatusCode.Unauthorized;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}
