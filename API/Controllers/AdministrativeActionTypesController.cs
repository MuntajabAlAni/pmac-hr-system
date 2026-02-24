using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdministrativeActionTypesController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AdministrativeActionTypeDto>>> GetAll()
    {
        var types = await serviceManager.AdministrativeActionTypeService.GetAll();
        return Ok(types);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<AdministrativeActionTypeDto>> GetById(Guid id)
    {
        var type = await serviceManager.AdministrativeActionTypeService.GetById(id);
        return Ok(type);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] AdministrativeActionTypeForCreationDto administrativeActionTypeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.AdministrativeActionTypeService.Create(administrativeActionTypeDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] AdministrativeActionTypeForUpdateDto administrativeActionTypeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.AdministrativeActionTypeService.Update(id, administrativeActionTypeDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.AdministrativeActionTypeService.Delete(id);
        return NoContent();
    }
}
