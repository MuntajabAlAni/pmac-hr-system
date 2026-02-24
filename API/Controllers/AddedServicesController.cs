using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddedServicesController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AddedServiceDto>>> GetAll()
    {
        var addedServices = await serviceManager.AddedServiceService.GetAll();
        return Ok(addedServices);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<AddedServiceDto>> GetById(Guid id)
    {
        var addedService = await serviceManager.AddedServiceService.GetById(id);
        return Ok(addedService);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] AddedServiceForCreationDto addedServiceDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.AddedServiceService.Create(addedServiceDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] AddedServiceForUpdateDto addedServiceDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.AddedServiceService.Update(id, addedServiceDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.AddedServiceService.Delete(id);
        return NoContent();
    }
}
