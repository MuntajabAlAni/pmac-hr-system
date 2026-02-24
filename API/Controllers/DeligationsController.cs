using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeligationsController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DeligationDto>>> GetAll()
    {
        var deligations = await serviceManager.DeligationService.GetAll();
        return Ok(deligations);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<DeligationDto>> GetById(Guid id)
    {
        var deligation = await serviceManager.DeligationService.GetById(id);
        return Ok(deligation);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] DeligationForCreationDto deligationDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.DeligationService.Create(deligationDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] DeligationForUpdateDto deligationDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.DeligationService.Update(id, deligationDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.DeligationService.Delete(id);
        return NoContent();
    }
}
