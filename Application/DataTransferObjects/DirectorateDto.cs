using System.ComponentModel.DataAnnotations;
using Domain.Entities.Organizations.Enums;

namespace Application.DataTransferObjects;

public class DirectorateDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public Guid HighAuthorityId { get; set; }
    public string? HighAuthorityName { get; set; }
    public Guid? SubHighAuthorityId { get; set; }
}

public class DirectorateForCreationDto
{
    [Required(ErrorMessage = "Directorate name is required")]
    [MaxLength(200)]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "HighAuthority ID is required")]
    public Guid HighAuthorityId { get; set; }

    public Guid? SubHighAuthorityId { get; set; }
}

public class DirectorateForUpdateDto
{
    [Required(ErrorMessage = "Directorate name is required")]
    [MaxLength(200)]
    public string Name { get; set; } = null!;
}
