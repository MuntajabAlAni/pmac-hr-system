namespace Application.DataTransferObjects;

public class UserForRegistrationDto : UserForManipulationDto
{
    public string SetPasswordUrl { get; set; } = null!;
}