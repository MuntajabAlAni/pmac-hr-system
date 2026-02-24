using AutoMapper;
using Domain.Models;
using Application.DataTransferObjects;

namespace Application.Mapping;

public class AddedServiceProfile : Profile
{
    public AddedServiceProfile()
    {
        CreateMap<AddedService, AddedServiceDto>()
            .ForMember(d => d.ServiceTypeName, opt => opt.MapFrom(s => s.ServiceType != null ? s.ServiceType.Name : null));
        CreateMap<AddedServiceForCreationDto, AddedService>();
        CreateMap<AddedServiceForUpdateDto, AddedService>();
    }
}
