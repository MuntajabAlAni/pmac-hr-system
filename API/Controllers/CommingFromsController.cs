using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommingFromsController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CommingFromDto>>> GetAll()
    {
        var result = await serviceManager.CommingFromService.GetAll();
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CommingFromDto>> GetById(Guid id)
    {
        var result = await serviceManager.CommingFromService.GetById(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CommingFromForCreationDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.CommingFromService.Create(dto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] CommingFromForUpdateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.CommingFromService.Update(id, dto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.CommingFromService.Delete(id);
        return NoContent();
    }
}
