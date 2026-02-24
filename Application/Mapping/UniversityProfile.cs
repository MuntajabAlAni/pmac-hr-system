using AutoMapper;
using Domain.Models;
using Application.DataTransferObjects;

namespace Application.Mapping;

public class UniversityProfile : Profile
{
    public UniversityProfile()
    {
        CreateMap<University, UniversityDto>();
        CreateMap<UniversityForCreationDto, University>();
        CreateMap<UniversityForUpdateDto, University>();
    }
}
