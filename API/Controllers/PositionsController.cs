using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PositionsController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PositionDto>>> GetAll()
    {
        var positions = await serviceManager.PositionService.GetAll();
        return Ok(positions);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PositionDto>> GetById(Guid id)
    {
        var position = await serviceManager.PositionService.GetById(id);
        return Ok(position);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] PositionForCreationDto positionDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.PositionService.Create(positionDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] PositionForUpdateDto positionDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.PositionService.Update(id, positionDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.PositionService.Delete(id);
        return NoContent();
    }
}
