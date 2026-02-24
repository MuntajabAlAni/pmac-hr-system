using AutoMapper;
using Domain.Models;
using Application.DataTransferObjects;

namespace Application.Mapping;

public class CertificatePublisherProfile : Profile
{
    public CertificatePublisherProfile()
    {
        CreateMap<CertificatePublisher, CertificatePublisherDto>();
        CreateMap<CertificatePublisherForCreationDto, CertificatePublisher>();
        CreateMap<CertificatePublisherForUpdateDto, CertificatePublisher>();
    }
}
