using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class SectionDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public Guid HighAuthorityId { get; set; }
    public Guid? SubHighAuthorityId { get; set; }
    public Guid? DirectorateId { get; set; }
    public Guid? SubDirectorateId { get; set; }
    public Guid? DepartmentId { get; set; }
    public string? DepartmentName { get; set; }
}

public class SectionForCreationDto
{
    [Required(ErrorMessage = "Section name is required")]
    [MaxLength(200)]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "HighAuthority ID is required")]
    public Guid HighAuthorityId { get; set; }

    public Guid? SubHighAuthorityId { get; set; }
    public Guid? DirectorateId { get; set; }
    public Guid? SubDirectorateId { get; set; }
    public Guid? DepartmentId { get; set; }
}

public class SectionForUpdateDto
{
    [Required(ErrorMessage = "Section name is required")]
    [MaxLength(200)]
    public string Name { get; set; } = null!;
}
