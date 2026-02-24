using AutoMapper;
using Domain.Models;
using Application.DataTransferObjects;

namespace Application.Mapping;

public class TrainingCourseProfile : Profile
{
    public TrainingCourseProfile()
    {
        CreateMap<TrainingCourse, TrainingCourseDto>()
             .ForMember(d => d.EmployeeFullName, opt => opt.MapFrom(s => s.Employee != null ? s.Employee.FirstName + " " + s.Employee.LastName : null));

        CreateMap<TrainingCourseForCreationDto, TrainingCourse>();
        CreateMap<TrainingCourseForUpdateDto, TrainingCourse>();
    }
}
