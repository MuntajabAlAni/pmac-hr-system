using AutoMapper;
using Domain.Models;
using Application.DataTransferObjects;

namespace Application.Mapping;

public class OfficialDocumentProfile : Profile
{
    public OfficialDocumentProfile()
    {
        CreateMap<OfficialDocument, OfficialDocumentDto>()
            .ForMember(d => d.EmployeeName, opt => opt.MapFrom(s => s.Employee != null ? s.Employee.FirstName + " " + s.Employee.LastName : null))
            .ForMember(d => d.DocumentTypeName, opt => opt.MapFrom(s => s.DocumentType != null ? s.DocumentType.Name : null));
        CreateMap<OfficialDocumentForCreationDto, OfficialDocument>();
        CreateMap<OfficialDocumentForUpdateDto, OfficialDocument>();
    }
}
