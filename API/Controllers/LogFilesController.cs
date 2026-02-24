using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LogFilesController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LogFileDto>>> GetAll()
    {
        var logFiles = await serviceManager.LogFileService.GetAll();
        return Ok(logFiles);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<LogFileDto>> GetById(Guid id)
    {
        var logFile = await serviceManager.LogFileService.GetById(id);
        return Ok(logFile);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] LogFileForCreationDto logFileDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await serviceManager.LogFileService.Create(logFileDto);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }
}
