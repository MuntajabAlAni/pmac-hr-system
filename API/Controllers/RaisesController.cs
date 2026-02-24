using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RaisesController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RaiseDto>>> GetAll()
    {
        var raises = await serviceManager.RaiseService.GetAll();
        return Ok(raises);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<RaiseDto>> GetById(Guid id)
    {
        var raise = await serviceManager.RaiseService.GetById(id);
        return Ok(raise);
    }

    [HttpGet("employee/{employeeId:guid}")]
    public async Task<ActionResult<IEnumerable<RaiseDto>>> GetByEmployeeId(Guid employeeId)
    {
        var raises = await serviceManager.RaiseService.GetByEmployeeId(employeeId);
        return Ok(raises);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] RaiseForCreationDto raiseDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.RaiseService.Create(raiseDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] RaiseForUpdateDto raiseDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.RaiseService.Update(id, raiseDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.RaiseService.Delete(id);
        return NoContent();
    }
}
