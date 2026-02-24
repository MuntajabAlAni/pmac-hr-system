using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class BasicSalaryDto
{
    public Guid Id { get; set; }
    public string? Salary { get; set; }
}

public class BasicSalaryForCreationDto
{
    [Required]
    public string? Salary { get; set; }
}

public class BasicSalaryForUpdateDto
{
    [Required]
    public string? Salary { get; set; }
}
