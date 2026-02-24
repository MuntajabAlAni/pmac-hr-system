using AutoMapper;
using Domain.Models;
using Application.DataTransferObjects;

namespace Application.Mapping;

public class AdministrativeActionProfile : Profile
{
    public AdministrativeActionProfile()
    {
        CreateMap<AdministrativeAction, AdministrativeActionDto>()
             .ForMember(d => d.EmployeeFullName, opt => opt.MapFrom(s => s.Employee != null ? s.Employee.FirstName + " " + s.Employee.LastName : null))
             .ForMember(d => d.ActionTypeName, opt => opt.MapFrom(s => s.ActionType != null ? s.ActionType.Name : null));

        CreateMap<AdministrativeActionForCreationDto, AdministrativeAction>();
        CreateMap<AdministrativeActionForUpdateDto, AdministrativeAction>();
    }
}
