using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StepsController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StepDto>>> GetAll()
    {
        var steps = await serviceManager.StepService.GetAll();
        return Ok(steps);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<StepDto>> GetById(Guid id)
    {
        var step = await serviceManager.StepService.GetById(id);
        return Ok(step);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] StepForCreationDto stepDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.StepService.Create(stepDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] StepForUpdateDto stepDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.StepService.Update(id, stepDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.StepService.Delete(id);
        return NoContent();
    }
}
