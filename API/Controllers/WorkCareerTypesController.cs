using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkCareerTypesController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<WorkCareerTypeDto>>> GetAll()
    {
        var workCareerTypes = await serviceManager.WorkCareerTypeService.GetAll();
        return Ok(workCareerTypes);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<WorkCareerTypeDto>> GetById(Guid id)
    {
        var workCareerType = await serviceManager.WorkCareerTypeService.GetById(id);
        return Ok(workCareerType);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] WorkCareerTypeForCreationDto workCareerTypeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.WorkCareerTypeService.Create(workCareerTypeDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] WorkCareerTypeForUpdateDto workCareerTypeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.WorkCareerTypeService.Update(id, workCareerTypeDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.WorkCareerTypeService.Delete(id);
        return NoContent();
    }
}
