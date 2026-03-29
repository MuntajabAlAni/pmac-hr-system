using AutoMapper;
using Domain.Entities.Employees;
using Application.DataTransferObjects;

namespace Application.Mapping;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeDto>();
        CreateMap<Employee, EmployeeDetailsDto>();
        // No DTO → Entity maps: entity construction is manual (DDD)
    }
}
