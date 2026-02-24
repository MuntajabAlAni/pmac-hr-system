using AutoMapper;
using Domain.Models;
using Application.DataTransferObjects;

namespace Application.Mapping;

public class OfficialDocumentTypeProfile : Profile
{
    public OfficialDocumentTypeProfile()
    {
        CreateMap<OfficialDocumentType, OfficialDocumentTypeDto>();
        CreateMap<OfficialDocumentTypeForCreationDto, OfficialDocumentType>();
        CreateMap<OfficialDocumentTypeForUpdateDto, OfficialDocumentType>();
    }
}
