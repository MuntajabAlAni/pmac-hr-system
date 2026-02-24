using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EducationCertificatesController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EducationCertificateDto>>> GetAll()
    {
        var certificates = await serviceManager.EducationCertificateService.GetAll();
        return Ok(certificates);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<EducationCertificateDto>> GetById(Guid id)
    {
        var certificate = await serviceManager.EducationCertificateService.GetById(id);
        return Ok(certificate);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] EducationCertificateForCreationDto educationCertificateDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.EducationCertificateService.Create(educationCertificateDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] EducationCertificateForUpdateDto educationCertificateDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.EducationCertificateService.Update(id, educationCertificateDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.EducationCertificateService.Delete(id);
        return NoContent();
    }
}
