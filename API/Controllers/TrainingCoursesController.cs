using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TrainingCoursesController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TrainingCourseDto>>> GetAll()
    {
        var trainingCourses = await serviceManager.TrainingCourseService.GetAll();
        return Ok(trainingCourses);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TrainingCourseDto>> GetById(Guid id)
    {
        var trainingCourse = await serviceManager.TrainingCourseService.GetById(id);
        return Ok(trainingCourse);
    }

    [HttpGet("employee/{employeeId:guid}")]
    public async Task<ActionResult<IEnumerable<TrainingCourseDto>>> GetByEmployeeId(Guid employeeId)
    {
        var trainingCourses = await serviceManager.TrainingCourseService.GetByEmployeeId(employeeId);
        return Ok(trainingCourses);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] TrainingCourseForCreationDto trainingCourseDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.TrainingCourseService.Create(trainingCourseDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] TrainingCourseForUpdateDto trainingCourseDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.TrainingCourseService.Update(id, trainingCourseDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.TrainingCourseService.Delete(id);
        return NoContent();
    }
}
