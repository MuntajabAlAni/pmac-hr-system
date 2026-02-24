using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoreEmployeesController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StoreEmployeeDto>>> GetAll()
    {
        var storeEmployees = await serviceManager.StoreEmployeeService.GetAll();
        return Ok(storeEmployees);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<StoreEmployeeDto>> GetById(Guid id)
    {
        var storeEmployee = await serviceManager.StoreEmployeeService.GetById(id);
        return Ok(storeEmployee);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] StoreEmployeeForCreationDto storeEmployeeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.StoreEmployeeService.Create(storeEmployeeDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] StoreEmployeeForUpdateDto storeEmployeeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.StoreEmployeeService.Update(id, storeEmployeeDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.StoreEmployeeService.Delete(id);
        return NoContent();
    }
}
