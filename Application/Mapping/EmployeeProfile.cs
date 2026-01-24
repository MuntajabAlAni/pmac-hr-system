using AutoMapper;
using Domain.Models;
using Application.DataTransferObjects;

namespace Application.Mapping;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee_Tbl, EmployeeDto>();
        CreateMap<Employee_Tbl, EmployeeDetailsDto>();
        CreateMap<EmployeeForCreationDto, Employee_Tbl>();
        CreateMap<EmployeeForUpdateDto, Employee_Tbl>();
    }
}
