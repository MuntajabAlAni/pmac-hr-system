using AutoMapper;
using Domain.Models;
using Application.DataTransferObjects;

namespace Application.Mapping;

public class TaskStatusProfile : Profile
{
    public TaskStatusProfile()
    {
        CreateMap<Domain.Models.TaskStatus, TaskStatusDto>();
        CreateMap<TaskStatusForCreationDto, Domain.Models.TaskStatus>();
        CreateMap<TaskStatusForUpdateDto, Domain.Models.TaskStatus>();
    }
}
