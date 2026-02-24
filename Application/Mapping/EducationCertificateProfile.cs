using AutoMapper;
using Domain.Models;
using Application.DataTransferObjects;

namespace Application.Mapping;

public class EducationCertificateProfile : Profile
{
    public EducationCertificateProfile()
    {
        CreateMap<EducationCertificate, EducationCertificateDto>()
            .ForMember(d => d.EmployeeName, opt => opt.MapFrom(s => s.EmployeeName ?? (s.Employee != null ? s.Employee.FirstName + " " + s.Employee.LastName : null)))
            .ForMember(d => d.CertificateName, opt => opt.MapFrom(s => s.Certificate != null ? s.Certificate.Name : null));
        CreateMap<EducationCertificateForCreationDto, EducationCertificate>();
        CreateMap<EducationCertificateForUpdateDto, EducationCertificate>();
    }
}
