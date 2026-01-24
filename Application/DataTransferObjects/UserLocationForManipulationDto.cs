namespace Application.DataTransferObjects;

public class UserLocationForManipulationDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Longitude { get; set; }
    public decimal Latitude { get; set; }
}
