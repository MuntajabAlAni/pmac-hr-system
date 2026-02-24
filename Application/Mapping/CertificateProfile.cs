using AutoMapper;
using Domain.Models;
using Application.DataTransferObjects;

namespace Application.Mapping;

public class CertificateProfile : Profile
{
    public CertificateProfile()
    {
        CreateMap<Certificate, CertificateDto>();
        CreateMap<CertificateForCreationDto, Certificate>();
        CreateMap<CertificateForUpdateDto, Certificate>();
    }
}
