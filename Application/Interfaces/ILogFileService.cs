using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface ILogFileService
{
    Task<IEnumerable<LogFileDto>> GetAll();
    Task<LogFileDto> GetById(Guid id);
    Task<Guid> Create(LogFileForCreationDto logFileDto);
}
