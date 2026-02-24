using AutoMapper;
using Domain.Models;
using Application.DataTransferObjects;

namespace Application.Mapping;

public class AdministrativeActionTypeProfile : Profile
{
    public AdministrativeActionTypeProfile()
    {
        CreateMap<AdministrativeActionType, AdministrativeActionTypeDto>();
        CreateMap<AdministrativeActionTypeForCreationDto, AdministrativeActionType>();
        CreateMap<AdministrativeActionTypeForUpdateDto, AdministrativeActionType>();
    }
}
