namespace ActivityHub.Exception.ExceptionBase;
public abstract class ActivityHubException : SystemException
{
    protected ActivityHubException(string message) : base(message) { }

    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();
}
