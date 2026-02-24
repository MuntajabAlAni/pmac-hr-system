using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CareersController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CareerDto>>> GetAll()
    {
        var careers = await serviceManager.CareerService.GetAll();
        return Ok(careers);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CareerDto>> GetById(Guid id)
    {
        var career = await serviceManager.CareerService.GetById(id);
        return Ok(career);
    }

    [HttpGet("employee/{employeeId:guid}")]
    public async Task<ActionResult<IEnumerable<CareerDto>>> GetByEmployeeId(Guid employeeId)
    {
        var careers = await serviceManager.CareerService.GetByEmployeeId(employeeId);
        return Ok(careers);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CareerForCreationDto careerDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.CareerService.Create(careerDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] CareerForUpdateDto careerDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.CareerService.Update(id, careerDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.CareerService.Delete(id);
        return NoContent();
    }
}
