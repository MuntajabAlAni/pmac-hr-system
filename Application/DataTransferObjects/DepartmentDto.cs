using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class DepartmentDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public Guid HighAuthorityId { get; set; }
    public string? HighAuthorityName { get; set; }
    public Guid? SubHighAuthorityId { get; set; }
    public Guid? DirectorateId { get; set; }
    public string? DirectorateName { get; set; }
    public Guid? SubDirectorateId { get; set; }
}

public class DepartmentForCreationDto
{
    [Required(ErrorMessage = "Department name is required")]
    [MaxLength(200)]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "HighAuthority ID is required")]
    public Guid HighAuthorityId { get; set; }

    public Guid? SubHighAuthorityId { get; set; }
    public Guid? DirectorateId { get; set; }
    public Guid? SubDirectorateId { get; set; }
}

public class DepartmentForUpdateDto
{
    [Required(ErrorMessage = "Department name is required")]
    [MaxLength(200)]
    public string Name { get; set; } = null!;
}
