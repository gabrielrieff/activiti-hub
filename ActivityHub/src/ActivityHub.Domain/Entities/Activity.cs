using ActivityHub.Domain.Enums;

namespace ActivityHub.Domain.Entities;
public class Activity : Base
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ActivityStatus Status { get; set; } = ActivityStatus.Describing;
    public int UserId { get; set; }
    public User User { get; set; } = default!;
}
