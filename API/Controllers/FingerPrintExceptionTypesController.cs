using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FingerPrintExceptionTypesController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FingerPrintExceptionTypeDto>>> GetAll()
    {
        var result = await serviceManager.FingerPrintExceptionTypeService.GetAll();
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<FingerPrintExceptionTypeDto>> GetById(Guid id)
    {
        var result = await serviceManager.FingerPrintExceptionTypeService.GetById(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] FingerPrintExceptionTypeForCreationDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.FingerPrintExceptionTypeService.Create(dto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] FingerPrintExceptionTypeForUpdateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.FingerPrintExceptionTypeService.Update(id, dto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.FingerPrintExceptionTypeService.Delete(id);
        return NoContent();
    }
}
