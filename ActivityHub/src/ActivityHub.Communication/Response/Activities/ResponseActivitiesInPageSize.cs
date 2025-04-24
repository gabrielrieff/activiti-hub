namespace ActivityHub.Communication.Response.Activities;
public class ResponseActivitiesInPageSize
{
    public int Page { get; set; }

    public int Size { get; set; }

    public int TotalRecords { get; set; }

    public int TotalPages { get; set; }

    public List<ResponseActivityJson> Data { get; set; } = [];
}
