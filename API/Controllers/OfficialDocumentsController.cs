using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OfficialDocumentsController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OfficialDocumentDto>>> GetAll()
    {
        var documents = await serviceManager.OfficialDocumentService.GetAll();
        return Ok(documents);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<OfficialDocumentDto>> GetById(Guid id)
    {
        var document = await serviceManager.OfficialDocumentService.GetById(id);
        return Ok(document);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] OfficialDocumentForCreationDto officialDocumentDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.OfficialDocumentService.Create(officialDocumentDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] OfficialDocumentForUpdateDto officialDocumentDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.OfficialDocumentService.Update(id, officialDocumentDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.OfficialDocumentService.Delete(id);
        return NoContent();
    }
}
