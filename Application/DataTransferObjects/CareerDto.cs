using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class CareerDto
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }

    // Movement Info
    public DateTime MovementDate { get; set; }
    public string? MovementType { get; set; }
    public string? Notes { get; set; }

    // Organization Snapshot
    public string? AuthorityName { get; set; }
    public string? SubAuthorityName { get; set; }
    public string? DirectorateName { get; set; }
    public string? SubDirectorateName { get; set; }
    public string? DepartmentName { get; set; }
    public string? SectionName { get; set; }
    public string? UnitName { get; set; }

    // Job Snapshot
    public string? JobTitle { get; set; }
    public string? GradeName { get; set; }
    public decimal BasicSalary { get; set; }
}

public class CareerForCreationDto
{
    [Required]
    public Guid EmployeeId { get; set; }

    [Required]
    public DateTime MovementDate { get; set; }

    [Required]
    [MaxLength(200)]
    public string MovementType { get; set; } = null!;

    [Required]
    [MaxLength(200)]
    public string AuthorityName { get; set; } = null!;

    [MaxLength(200)]
    public string? SubAuthorityName { get; set; }

    [Required]
    [MaxLength(200)]
    public string DirectorateName { get; set; } = null!;

    [MaxLength(200)]
    public string? SubDirectorateName { get; set; }

    [Required]
    [MaxLength(200)]
    public string DepartmentName { get; set; } = null!;

    [Required]
    [MaxLength(200)]
    public string SectionName { get; set; } = null!;

    [MaxLength(200)]
    public string? UnitName { get; set; }

    [Required]
    [MaxLength(200)]
    public string JobTitle { get; set; } = null!;

    [Required]
    [MaxLength(200)]
    public string GradeName { get; set; } = null!;

    [Required]
    public decimal BasicSalary { get; set; }

    public string? Notes { get; set; }
}

public class CareerForUpdateDto
{
    public string? Notes { get; set; }
}
