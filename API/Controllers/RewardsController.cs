using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RewardsController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RewardDto>>> GetAll()
    {
        var rewards = await serviceManager.RewardService.GetAll();
        return Ok(rewards);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<RewardDto>> GetById(Guid id)
    {
        var reward = await serviceManager.RewardService.GetById(id);
        return Ok(reward);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] RewardForCreationDto rewardDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.RewardService.Create(rewardDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] RewardForUpdateDto rewardDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.RewardService.Update(id, rewardDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.RewardService.Delete(id);
        return NoContent();
    }
}
