using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VacationTypesController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VacationTypeDto>>> GetAll()
    {
        var vacationTypes = await serviceManager.VacationTypeService.GetAll();
        return Ok(vacationTypes);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<VacationTypeDto>> GetById(Guid id)
    {
        var vacationType = await serviceManager.VacationTypeService.GetById(id);
        return Ok(vacationType);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] VacationTypeForCreationDto vacationTypeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.VacationTypeService.Create(vacationTypeDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] VacationTypeForUpdateDto vacationTypeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.VacationTypeService.Update(id, vacationTypeDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.VacationTypeService.Delete(id);
        return NoContent();
    }
}
