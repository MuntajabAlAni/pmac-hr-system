using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OfficialDocumentTypesController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OfficialDocumentTypeDto>>> GetAll()
    {
        var types = await serviceManager.OfficialDocumentTypeService.GetAll();
        return Ok(types);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<OfficialDocumentTypeDto>> GetById(Guid id)
    {
        var type = await serviceManager.OfficialDocumentTypeService.GetById(id);
        return Ok(type);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] OfficialDocumentTypeForCreationDto officialDocumentTypeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.OfficialDocumentTypeService.Create(officialDocumentTypeDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] OfficialDocumentTypeForUpdateDto officialDocumentTypeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.OfficialDocumentTypeService.Update(id, officialDocumentTypeDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.OfficialDocumentTypeService.Delete(id);
        return NoContent();
    }
}
