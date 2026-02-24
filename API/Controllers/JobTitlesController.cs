using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobTitlesController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<JobTitleDto>>> GetAll()
    {
        var jobTitles = await serviceManager.JobTitleService.GetAll();
        return Ok(jobTitles);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<JobTitleDto>> GetById(Guid id)
    {
        var jobTitle = await serviceManager.JobTitleService.GetById(id);
        return Ok(jobTitle);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] JobTitleForCreationDto jobTitleDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.JobTitleService.Create(jobTitleDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] JobTitleForUpdateDto jobTitleDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.JobTitleService.Update(id, jobTitleDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.JobTitleService.Delete(id);
        return NoContent();
    }
}
