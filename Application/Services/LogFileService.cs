using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class LogFileService(IRepositoryManager repositoryManager, IMapper mapper) : ILogFileService
{
    public async Task<IEnumerable<LogFileDto>> GetAll()
    {
        var logFiles = await repositoryManager.LogFile.FindAll();
        return mapper.Map<IEnumerable<LogFileDto>>(logFiles);
    }

    public async Task<LogFileDto> GetById(Guid id)
    {
        var logFile = await repositoryManager.LogFile.FindById(id);
        if (logFile is null)
            throw new EntityNotFoundException("LogFile", "Id", id);

        return mapper.Map<LogFileDto>(logFile);
    }

    public async Task<Guid> Create(LogFileForCreationDto logFileDto)
    {
        var logFile = mapper.Map<LogFile>(logFileDto);
        logFile.EntryTime = DateTime.UtcNow;
        return await repositoryManager.LogFile.Create(logFile);
    }
}
