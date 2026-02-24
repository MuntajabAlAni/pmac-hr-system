using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DirectoratesController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DirectorateDto>>> GetAll()
    {
        var directorates = await serviceManager.DirectorateService.GetAll();
        return Ok(directorates);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<DirectorateDto>> GetById(Guid id)
    {
        var directorate = await serviceManager.DirectorateService.GetById(id);
        return Ok(directorate);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] DirectorateForCreationDto directorateDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.DirectorateService.Create(directorateDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] DirectorateForUpdateDto directorateDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.DirectorateService.Update(id, directorateDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.DirectorateService.Delete(id);
        return NoContent();
    }
}
