
namespace ActivityHub.Exception.ExceptionBase;
public class NotFoundException : ActivityHubException
{
    public NotFoundException(string messages) : base(messages) { }

    public override int StatusCode => throw new NotImplementedException();

    public override List<string> GetErrors()
    {
        return [Message];
    }
}
