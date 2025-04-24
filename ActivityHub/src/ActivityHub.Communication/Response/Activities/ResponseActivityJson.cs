using ActivityHub.Communication.Enums;

namespace ActivityHub.Communication.Response.Activities;
public class ResponseActivityJson
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ActivityStatus Status { get; set; }
}
