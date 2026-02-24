using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VacationTotalsController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VacationTotalDto>>> GetAll()
    {
        var vacationTotals = await serviceManager.VacationTotalService.GetAll();
        return Ok(vacationTotals);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<VacationTotalDto>> GetById(Guid id)
    {
        var vacationTotal = await serviceManager.VacationTotalService.GetById(id);
        return Ok(vacationTotal);
    }

    [HttpGet("employee/{employeeId:guid}")]
    public async Task<ActionResult<VacationTotalDto>> GetByEmployeeId(Guid employeeId)
    {
        var vacationTotal = await serviceManager.VacationTotalService.GetByEmployeeId(employeeId);
        return Ok(vacationTotal);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] VacationTotalForCreationDto vacationTotalDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.VacationTotalService.Create(vacationTotalDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] VacationTotalForUpdateDto vacationTotalDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.VacationTotalService.Update(id, vacationTotalDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.VacationTotalService.Delete(id);
        return NoContent();
    }
}
