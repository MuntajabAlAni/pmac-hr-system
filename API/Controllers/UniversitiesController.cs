using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UniversitiesController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UniversityDto>>> GetAll()
    {
        var universities = await serviceManager.UniversityService.GetAll();
        return Ok(universities);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UniversityDto>> GetById(Guid id)
    {
        var university = await serviceManager.UniversityService.GetById(id);
        return Ok(university);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] UniversityForCreationDto universityDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.UniversityService.Create(universityDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] UniversityForUpdateDto universityDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.UniversityService.Update(id, universityDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.UniversityService.Delete(id);
        return NoContent();
    }
}
