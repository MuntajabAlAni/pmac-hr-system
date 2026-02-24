using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CertificatesController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CertificateDto>>> GetAll()
    {
        var certificates = await serviceManager.CertificateService.GetAll();
        return Ok(certificates);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CertificateDto>> GetById(Guid id)
    {
        var certificate = await serviceManager.CertificateService.GetById(id);
        return Ok(certificate);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CertificateForCreationDto certificateDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.CertificateService.Create(certificateDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] CertificateForUpdateDto certificateDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.CertificateService.Update(id, certificateDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.CertificateService.Delete(id);
        return NoContent();
    }
}
