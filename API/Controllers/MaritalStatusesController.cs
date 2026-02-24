using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MaritalStatusesController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MaritalStatusDto>>> GetAll()
    {
        var maritalStatuses = await serviceManager.MaritalStatusService.GetAll();
        return Ok(maritalStatuses);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<MaritalStatusDto>> GetById(Guid id)
    {
        var maritalStatus = await serviceManager.MaritalStatusService.GetById(id);
        return Ok(maritalStatus);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] MaritalStatusForCreationDto maritalStatusDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.MaritalStatusService.Create(maritalStatusDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] MaritalStatusForUpdateDto maritalStatusDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.MaritalStatusService.Update(id, maritalStatusDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.MaritalStatusService.Delete(id);
        return NoContent();
    }
}
