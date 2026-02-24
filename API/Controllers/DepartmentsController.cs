using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentsController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetAll()
    {
        var departments = await serviceManager.DepartmentService.GetAll();
        return Ok(departments);
    }

    [HttpGet("by-directorate/{directorateId:guid}")]
    public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetByDirectorate(Guid directorateId)
    {
        var departments = await serviceManager.DepartmentService.GetByDirectorateId(directorateId);
        return Ok(departments);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<DepartmentDto>> GetById(Guid id)
    {
        var department = await serviceManager.DepartmentService.GetById(id);
        return Ok(department);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] DepartmentForCreationDto departmentDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.DepartmentService.Create(departmentDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] DepartmentForUpdateDto departmentDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.DepartmentService.Update(id, departmentDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.DepartmentService.Delete(id);
        return NoContent();
    }
}
