using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceContinuationsController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ServiceContinuationDto>>> GetAll()
    {
        var serviceContinuations = await serviceManager.ServiceContinuationService.GetAll();
        return Ok(serviceContinuations);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ServiceContinuationDto>> GetById(Guid id)
    {
        var serviceContinuation = await serviceManager.ServiceContinuationService.GetById(id);
        return Ok(serviceContinuation);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] ServiceContinuationForCreationDto serviceContinuationDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.ServiceContinuationService.Create(serviceContinuationDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] ServiceContinuationForUpdateDto serviceContinuationDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.ServiceContinuationService.Update(id, serviceContinuationDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.ServiceContinuationService.Delete(id);
        return NoContent();
    }
}
