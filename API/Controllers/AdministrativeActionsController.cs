using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdministrativeActionsController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AdministrativeActionDto>>> GetAll()
    {
        var actions = await serviceManager.AdministrativeActionService.GetAll();
        return Ok(actions);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<AdministrativeActionDto>> GetById(Guid id)
    {
        var action = await serviceManager.AdministrativeActionService.GetById(id);
        return Ok(action);
    }

    [HttpGet("employee/{employeeId:guid}")]
    public async Task<ActionResult<IEnumerable<AdministrativeActionDto>>> GetByEmployeeId(Guid employeeId)
    {
        var actions = await serviceManager.AdministrativeActionService.GetByEmployeeId(employeeId);
        return Ok(actions);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] AdministrativeActionForCreationDto administrativeActionDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.AdministrativeActionService.Create(administrativeActionDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] AdministrativeActionForUpdateDto administrativeActionDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.AdministrativeActionService.Update(id, administrativeActionDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.AdministrativeActionService.Delete(id);
        return NoContent();
    }
}
