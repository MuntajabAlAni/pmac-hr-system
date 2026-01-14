using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace Shared.Helpers.Mapping;

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
