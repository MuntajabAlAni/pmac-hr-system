using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;
using Domain.RequestFeatures;

namespace API.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class EmployeesController(IServiceManager serviceManager) : ControllerBase
{
    /// <summary>
    /// Get all employees with pagination
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAll([FromQuery] PaginationParameters parameters)
    {
        var (employees, totalCount) = await serviceManager.EmployeeService.GetAll(parameters);

        Response.Headers.Add("X-Total-Count", totalCount.ToString());
        Response.Headers.Add("X-Page-Number", parameters.PageNumber.ToString());
        Response.Headers.Add("X-Page-Size", parameters.PageSize.ToString());

        return Ok(employees);
    }

    /// <summary>
    /// Search employees by name, ID, or phone
    /// </summary>
    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> Search(
        [FromQuery] string searchTerm,
        [FromQuery] PaginationParameters parameters)
    {
        var (employees, totalCount) = await serviceManager.EmployeeService.Search(searchTerm, parameters);

        Response.Headers.Add("X-Total-Count", totalCount.ToString());

        return Ok(employees);
    }

    /// <summary>
    /// Get employee by ID with full details
    /// </summary>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<EmployeeDetailsDto>> GetById(Guid id)
    {
        var employee = await serviceManager.EmployeeService.GetById(id);
        return Ok(employee);
    }

    /// <summary>
    /// Create a new employee
    /// </summary>
    [HttpPost]
    [Authorize(Policy = "RequireAddUserPermission")]
    public async Task<ActionResult<Guid>> Create([FromBody] EmployeeForCreationDto employeeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.EmployeeService.Create(employeeDto);

        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    /// <summary>
    /// Update an existing employee
    /// </summary>
    [HttpPut("{id:guid}")]
    [Authorize(Policy = "RequireEditUserPermission")]
    public async Task<ActionResult> Update(Guid id, [FromBody] EmployeeForUpdateDto employeeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.EmployeeService.Update(id, employeeDto);

        return NoContent();
    }

    /// <summary>
    /// Delete an employee (soft delete)
    /// </summary>
    [HttpDelete("{id:guid}")]
    [Authorize(Policy = "RequireDeleteUserPermission")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.EmployeeService.Delete(id);
        return NoContent();
    }
}
