using AutoMapper;
using Domain.Models;
using Application.DataTransferObjects;

namespace Application.Mapping;

public class RaiseProfile : Profile
{
    public RaiseProfile()
    {
        CreateMap<BasicSalary, BasicSalaryDto>();
        CreateMap<BasicSalaryForCreationDto, BasicSalary>();
        CreateMap<BasicSalaryForUpdateDto, BasicSalary>();

        CreateMap<RaiseType, RaiseTypeDto>();
        CreateMap<RaiseTypeForCreationDto, RaiseType>();
        CreateMap<RaiseTypeForUpdateDto, RaiseType>();

        CreateMap<Raise, RaiseDto>()
            .ForMember(d => d.RaiseTypeName, opt => opt.MapFrom(s => s.RaiseType != null ? s.RaiseType.Name : null))
            .ForMember(d => d.EmployeeName, opt => opt.MapFrom(s => s.Employee != null ? s.Employee.FirstName + " " + s.Employee.LastName : null))
            .ForMember(d => d.OldGradeName, opt => opt.MapFrom(s => s.OldGrade != null ? s.OldGrade.Name : null))
            .ForMember(d => d.NewGradeName, opt => opt.MapFrom(s => s.NewGrade != null ? s.NewGrade.Name : null))
            .ForMember(d => d.OldStepName, opt => opt.MapFrom(s => s.OldStep != null ? s.OldStep.Name : null))
            .ForMember(d => d.NewStepName, opt => opt.MapFrom(s => s.NewStep != null ? s.NewStep.Name : null));

        CreateMap<RaiseForCreationDto, Raise>();
        CreateMap<RaiseForUpdateDto, Raise>();
    }
}
