using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class VacationTotalDto
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public string? EmployeeName { get; set; }
    public string? OrdinaryVacationTotal { get; set; }
    public string? IllnessVacationTotal { get; set; }
    public string? OrdinaryFinalTotal { get; set; }
    public string? IllnessFinalTotal { get; set; }
}

public class VacationTotalForCreationDto
{
    [Required]
    public Guid EmployeeId { get; set; }
    public string? OrdinaryVacationTotal { get; set; }
    public string? IllnessVacationTotal { get; set; }
    public string? OrdinaryFinalTotal { get; set; }
    public string? IllnessFinalTotal { get; set; }
}

public class VacationTotalForUpdateDto
{
    [Required]
    public Guid EmployeeId { get; set; }
    public string? OrdinaryVacationTotal { get; set; }
    public string? IllnessVacationTotal { get; set; }
    public string? OrdinaryFinalTotal { get; set; }
    public string? IllnessFinalTotal { get; set; }
}
