using ActivityHub.Communication.Enums;

namespace ActivityHub.Communication.Response.Activities;
public class ResponseRegisterActivityJson
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ActivityStatus Status { get; set; } = ActivityStatus.Describing;
}
