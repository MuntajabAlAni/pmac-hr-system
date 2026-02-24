using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SectionsController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SectionDto>>> GetAll()
    {
        var sections = await serviceManager.SectionService.GetAll();
        return Ok(sections);
    }

    [HttpGet("by-department/{departmentId:guid}")]
    public async Task<ActionResult<IEnumerable<SectionDto>>> GetByDepartment(Guid departmentId)
    {
        var sections = await serviceManager.SectionService.GetByDepartmentId(departmentId);
        return Ok(sections);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<SectionDto>> GetById(Guid id)
    {
        var section = await serviceManager.SectionService.GetById(id);
        return Ok(section);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] SectionForCreationDto sectionDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.SectionService.Create(sectionDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] SectionForUpdateDto sectionDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.SectionService.Update(id, sectionDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.SectionService.Delete(id);
        return NoContent();
    }
}
