using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VacationsController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VacationDto>>> GetAll()
    {
        var vacations = await serviceManager.VacationService.GetAll();
        return Ok(vacations);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<VacationDto>> GetById(Guid id)
    {
        var vacation = await serviceManager.VacationService.GetById(id);
        return Ok(vacation);
    }

    [HttpGet("employee/{employeeId:guid}")]
    public async Task<ActionResult<IEnumerable<VacationDto>>> GetByEmployeeId(Guid employeeId)
    {
        var vacations = await serviceManager.VacationService.GetByEmployeeId(employeeId);
        return Ok(vacations);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] VacationForCreationDto vacationDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.VacationService.Create(vacationDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] VacationForUpdateDto vacationDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.VacationService.Update(id, vacationDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.VacationService.Delete(id);
        return NoContent();
    }
}
