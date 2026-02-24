using AutoMapper;
using Domain.Models;
using Application.DataTransferObjects;

namespace Application.Mapping;

public class DeligationProfile : Profile
{
    public DeligationProfile()
    {
        CreateMap<Deligation, DeligationDto>()
            .ForMember(d => d.EmployeeName, opt => opt.MapFrom(s => s.EmployeeName ?? (s.Employee != null ? s.Employee.FirstName + " " + s.Employee.LastName : null)));
        CreateMap<DeligationForCreationDto, Deligation>();
        CreateMap<DeligationForUpdateDto, Deligation>();
    }
}
