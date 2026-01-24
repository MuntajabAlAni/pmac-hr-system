namespace Domain.Models;

public class UserLocation
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Longitude { get; set; }
    public decimal Latitude { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime RecordDate { get; set; }
}
