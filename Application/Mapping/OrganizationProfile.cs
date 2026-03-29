using AutoMapper;
using Domain.Entities.Organizations;
using Domain.Entities.EmploymentStructure;
using Domain.Models;
using Application.DataTransferObjects;

namespace Application.Mapping;

public class OrganizationProfile : Profile
{
    public OrganizationProfile()
    {
        CreateMap<Directorate, DirectorateDto>();
        // No DTO → Entity maps for Directorate (DDD)

        CreateMap<Department, DepartmentDto>();
        // No DTO → Entity maps for Department (DDD)

        CreateMap<Section, SectionDto>();
        // No DTO → Entity maps for Section (DDD)

        CreateMap<Position, PositionDto>();
        // No DTO → Entity maps for Position (DDD)

        CreateMap<JobTitle, JobTitleDto>();
        // No DTO → Entity maps for JobTitle (DDD)

        CreateMap<Rank, RankDto>();
        CreateMap<RankForCreationDto, Rank>();
        CreateMap<RankForUpdateDto, Rank>();

        CreateMap<StoreEmployee, StoreEmployeeDto>();
        CreateMap<StoreEmployeeForCreationDto, StoreEmployee>();
        CreateMap<StoreEmployeeForUpdateDto, StoreEmployee>();
    }
}
