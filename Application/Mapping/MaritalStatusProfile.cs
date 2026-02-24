using AutoMapper;
using Domain.Models;
using Application.DataTransferObjects;

namespace Application.Mapping;

public class MaritalStatusProfile : Profile
{
    public MaritalStatusProfile()
    {
        CreateMap<MaritalStatus, MaritalStatusDto>();
        CreateMap<MaritalStatusForCreationDto, MaritalStatus>();
        CreateMap<MaritalStatusForUpdateDto, MaritalStatus>();
    }
}
