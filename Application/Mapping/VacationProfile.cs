using AutoMapper;
using Domain.Models;
using Application.DataTransferObjects;

namespace Application.Mapping;

public class VacationProfile : Profile
{
    public VacationProfile()
    {
        CreateMap<VacationType, VacationTypeDto>();
        CreateMap<VacationTypeForCreationDto, VacationType>();
        CreateMap<VacationTypeForUpdateDto, VacationType>();

        CreateMap<Vacation, VacationDto>()
            .ForMember(d => d.VacationTypeName, opt => opt.MapFrom(s => s.VacationType != null ? s.VacationType.Name : null))
            // Assuming Employee model has FirstName and LastName as verified previously
            .ForMember(d => d.EmployeeName, opt => opt.MapFrom(s => s.Employee != null ? s.Employee.FirstName + " " + s.Employee.LastName : null));

        CreateMap<VacationForCreationDto, Vacation>();
        CreateMap<VacationForUpdateDto, Vacation>();

        CreateMap<VacationTotal, VacationTotalDto>()
            .ForMember(d => d.EmployeeName, opt => opt.MapFrom(s => s.Employee != null ? s.Employee.FirstName + " " + s.Employee.LastName : null));
        CreateMap<VacationTotalForCreationDto, VacationTotal>();
        CreateMap<VacationTotalForUpdateDto, VacationTotal>();
    }
}
