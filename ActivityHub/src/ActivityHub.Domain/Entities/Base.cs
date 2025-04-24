namespace ActivityHub.Domain.Entities;
public class Base
{
    public int Id { get; set; }
    public DateTime UpdateAt { get; set; } = DateTime.UtcNow;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
