using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConsultantTasksController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ConsultantTaskDto>>> GetAll()
    {
        var consultantTasks = await serviceManager.ConsultantTaskService.GetAll();
        return Ok(consultantTasks);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ConsultantTaskDto>> GetById(Guid id)
    {
        var consultantTask = await serviceManager.ConsultantTaskService.GetById(id);
        return Ok(consultantTask);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] ConsultantTaskForCreationDto consultantTaskDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.ConsultantTaskService.Create(consultantTaskDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] ConsultantTaskForUpdateDto consultantTaskDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.ConsultantTaskService.Update(id, consultantTaskDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.ConsultantTaskService.Delete(id);
        return NoContent();
    }
}
