using AutoMapper;
using Domain.Models;
using Application.DataTransferObjects;

namespace Application.Mapping;

public class LogFileProfile : Profile
{
    public LogFileProfile()
    {
        CreateMap<LogFile, LogFileDto>();
        CreateMap<LogFileForCreationDto, LogFile>();
    }
}
