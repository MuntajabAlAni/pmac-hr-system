using AutoMapper;
using Domain.Models;
using Application.DataTransferObjects;

namespace Application.Mapping;

public class ConsultantTaskProfile : Profile
{
    public ConsultantTaskProfile()
    {
        CreateMap<ConsultantTask, ConsultantTaskDto>()
            .ForMember(d => d.TaskDescriptionName, opt => opt.MapFrom(s => s.TaskDescription != null ? s.TaskDescription.Description : null))
            .ForMember(d => d.WorkNatureName, opt => opt.MapFrom(s => s.WorkNature != null ? s.WorkNature.Name : null))
            .ForMember(d => d.TaskStatusName, opt => opt.MapFrom(s => s.TaskStatus != null ? s.TaskStatus.Name : null))
            .ForMember(d => d.ProcedureDescriptionName, opt => opt.MapFrom(s => s.ProcedureDescription != null ? s.ProcedureDescription.Description : null));
        CreateMap<ConsultantTaskForCreationDto, ConsultantTask>();
        CreateMap<ConsultantTaskForUpdateDto, ConsultantTask>();
    }
}
