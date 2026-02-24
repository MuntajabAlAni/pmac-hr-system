using AutoMapper;
using Domain.Models;
using Application.DataTransferObjects;

namespace Application.Mapping;

public class OrganizationProfile : Profile
{
    public OrganizationProfile()
    {
        CreateMap<Directorate, DirectorateDto>();
        CreateMap<DirectorateForCreationDto, Directorate>();
        CreateMap<DirectorateForUpdateDto, Directorate>();

        CreateMap<Department, DepartmentDto>();
        CreateMap<DepartmentForCreationDto, Department>();
        CreateMap<DepartmentForUpdateDto, Department>();

        CreateMap<Section, SectionDto>();
        CreateMap<SectionForCreationDto, Section>();
        CreateMap<SectionForUpdateDto, Section>();

        CreateMap<Position, PositionDto>();
        CreateMap<PositionForCreationDto, Position>();
        CreateMap<PositionForUpdateDto, Position>();

        CreateMap<JobTitle, JobTitleDto>();
        CreateMap<JobTitleForCreationDto, JobTitle>();
        CreateMap<JobTitleForUpdateDto, JobTitle>();

        CreateMap<Rank, RankDto>();
        CreateMap<RankForCreationDto, Rank>();
        CreateMap<RankForUpdateDto, Rank>();

        CreateMap<StoreEmployee, StoreEmployeeDto>();
        CreateMap<StoreEmployeeForCreationDto, StoreEmployee>();
        CreateMap<StoreEmployeeForUpdateDto, StoreEmployee>();
    }
}
