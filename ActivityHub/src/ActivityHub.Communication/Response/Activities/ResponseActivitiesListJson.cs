namespace ActivityHub.Communication.Response.Activities;
public class ResponseActivitiesListJson
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public List<ResponseActivityJson> ListActivities { get; set; } = [];
}
