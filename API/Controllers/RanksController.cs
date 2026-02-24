using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RanksController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RankDto>>> GetAll()
    {
        var ranks = await serviceManager.RankService.GetAll();
        return Ok(ranks);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<RankDto>> GetById(Guid id)
    {
        var rank = await serviceManager.RankService.GetById(id);
        return Ok(rank);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] RankForCreationDto rankDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.RankService.Create(rankDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] RankForUpdateDto rankDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.RankService.Update(id, rankDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.RankService.Delete(id);
        return NoContent();
    }
}
