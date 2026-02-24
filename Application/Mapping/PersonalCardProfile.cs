using AutoMapper;
using Domain.Models;
using Application.DataTransferObjects;

namespace Application.Mapping;

public class PersonalCardProfile : Profile
{
    public PersonalCardProfile()
    {
        CreateMap<PersonalCard, PersonalCardDto>()
            .ForMember(d => d.EmployeeName, opt => opt.MapFrom(s => s.EmployeeName ?? (s.Employee != null ? s.Employee.FirstName + " " + s.Employee.LastName : null)));
        CreateMap<PersonalCardForCreationDto, PersonalCard>();
        CreateMap<PersonalCardForUpdateDto, PersonalCard>();
    }
}
