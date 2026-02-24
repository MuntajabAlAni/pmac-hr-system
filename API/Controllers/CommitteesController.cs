using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommitteesController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CommitteeDto>>> GetAll()
    {
        var committees = await serviceManager.CommitteeService.GetAll();
        return Ok(committees);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CommitteeDto>> GetById(Guid id)
    {
        var committee = await serviceManager.CommitteeService.GetById(id);
        return Ok(committee);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CommitteeForCreationDto committeeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.CommitteeService.Create(committeeDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] CommitteeForUpdateDto committeeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.CommitteeService.Update(id, committeeDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.CommitteeService.Delete(id);
        return NoContent();
    }
}
