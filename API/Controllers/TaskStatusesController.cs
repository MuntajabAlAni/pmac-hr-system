using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskStatusesController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskStatusDto>>> GetAll()
    {
        var taskStatuses = await serviceManager.TaskStatusService.GetAll();
        return Ok(taskStatuses);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TaskStatusDto>> GetById(Guid id)
    {
        var taskStatus = await serviceManager.TaskStatusService.GetById(id);
        return Ok(taskStatus);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] TaskStatusForCreationDto taskStatusDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.TaskStatusService.Create(taskStatusDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] TaskStatusForUpdateDto taskStatusDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.TaskStatusService.Update(id, taskStatusDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.TaskStatusService.Delete(id);
        return NoContent();
    }
}
