using AutoMapper;
using Domain.Models;
using Application.DataTransferObjects;

namespace Application.Mapping;

public class CommitteeProfile : Profile
{
    public CommitteeProfile()
    {
        CreateMap<Committee, CommitteeDto>()
             .ForMember(d => d.EmployeeName, opt => opt.MapFrom(s => s.EmployeeName ?? (s.Employee != null ? s.Employee.FirstName + " " + s.Employee.LastName : null)));
        CreateMap<CommitteeForCreationDto, Committee>();
        CreateMap<CommitteeForUpdateDto, Committee>();
    }
}
