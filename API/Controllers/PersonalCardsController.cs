using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonalCardsController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PersonalCardDto>>> GetAll()
    {
        var personalCards = await serviceManager.PersonalCardService.GetAll();
        return Ok(personalCards);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PersonalCardDto>> GetById(Guid id)
    {
        var personalCard = await serviceManager.PersonalCardService.GetById(id);
        return Ok(personalCard);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] PersonalCardForCreationDto personalCardDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.PersonalCardService.Create(personalCardDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] PersonalCardForUpdateDto personalCardDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await serviceManager.PersonalCardService.Update(id, personalCardDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await serviceManager.PersonalCardService.Delete(id);
        return NoContent();
    }
}
