using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RaiseTypesController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RaiseTypeDto>>> GetAll()
    {
        var raiseTypes = await serviceManager.RaiseTypeService.GetAll();
        return Ok(raiseTypes);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<RaiseTypeDto>> GetById(Guid id)
    {
        var raiseType = await serviceManager.RaiseTypeService.GetById(id);
        return Ok(raiseType);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] RaiseTypeForCreationDto raiseTypeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.RaiseTypeService.Create(raiseTypeDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] RaiseTypeForUpdateDto raiseTypeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.RaiseTypeService.Update(id, raiseTypeDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.RaiseTypeService.Delete(id);
        return NoContent();
    }
}
