using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GradesController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GradeDto>>> GetAll()
    {
        var grades = await serviceManager.GradeService.GetAll();
        return Ok(grades);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GradeDto>> GetById(Guid id)
    {
        var grade = await serviceManager.GradeService.GetById(id);
        return Ok(grade);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] GradeForCreationDto gradeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.GradeService.Create(gradeDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] GradeForUpdateDto gradeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.GradeService.Update(id, gradeDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.GradeService.Delete(id);
        return NoContent();
    }
}
