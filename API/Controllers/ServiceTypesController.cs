using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceTypesController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ServiceTypeDto>>> GetAll()
    {
        var serviceTypes = await serviceManager.ServiceTypeService.GetAll();
        return Ok(serviceTypes);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ServiceTypeDto>> GetById(Guid id)
    {
        var serviceType = await serviceManager.ServiceTypeService.GetById(id);
        return Ok(serviceType);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] ServiceTypeForCreationDto serviceTypeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.ServiceTypeService.Create(serviceTypeDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] ServiceTypeForUpdateDto serviceTypeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.ServiceTypeService.Update(id, serviceTypeDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.ServiceTypeService.Delete(id);
        return NoContent();
    }
}
