using AutoMapper;
using Domain.Models;
using Application.DataTransferObjects;

namespace Application.Mapping;

public class ServiceTypeProfile : Profile
{
    public ServiceTypeProfile()
    {
        CreateMap<ServiceType, ServiceTypeDto>();
        CreateMap<ServiceTypeForCreationDto, ServiceType>();
        CreateMap<ServiceTypeForUpdateDto, ServiceType>();
    }
}
