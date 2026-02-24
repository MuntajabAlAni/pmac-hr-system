using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CertificatePublishersController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CertificatePublisherDto>>> GetAll()
    {
        var certificatePublishers = await serviceManager.CertificatePublisherService.GetAll();
        return Ok(certificatePublishers);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CertificatePublisherDto>> GetById(Guid id)
    {
        var certificatePublisher = await serviceManager.CertificatePublisherService.GetById(id);
        return Ok(certificatePublisher);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CertificatePublisherForCreationDto certificatePublisherDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.CertificatePublisherService.Create(certificatePublisherDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] CertificatePublisherForUpdateDto certificatePublisherDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.CertificatePublisherService.Update(id, certificatePublisherDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.CertificatePublisherService.Delete(id);
        return NoContent();
    }
}
