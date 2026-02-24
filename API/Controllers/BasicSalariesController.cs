using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BasicSalariesController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BasicSalaryDto>>> GetAll()
    {
        var basicSalaries = await serviceManager.BasicSalaryService.GetAll();
        return Ok(basicSalaries);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<BasicSalaryDto>> GetById(Guid id)
    {
        var basicSalary = await serviceManager.BasicSalaryService.GetById(id);
        return Ok(basicSalary);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] BasicSalaryForCreationDto basicSalaryDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.BasicSalaryService.Create(basicSalaryDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] BasicSalaryForUpdateDto basicSalaryDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.BasicSalaryService.Update(id, basicSalaryDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.BasicSalaryService.Delete(id);
        return NoContent();
    }
}
