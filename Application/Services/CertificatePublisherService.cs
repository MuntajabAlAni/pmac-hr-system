using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class CertificatePublisherService(IRepositoryManager repositoryManager, IMapper mapper) : ICertificatePublisherService
{
    public async Task<IEnumerable<CertificatePublisherDto>> GetAll()
    {
        var certificatePublishers = await repositoryManager.CertificatePublisher.FindAll();
        return mapper.Map<IEnumerable<CertificatePublisherDto>>(certificatePublishers);
    }

    public async Task<CertificatePublisherDto> GetById(Guid id)
    {
        var certificatePublisher = await repositoryManager.CertificatePublisher.FindById(id);
        if (certificatePublisher is null)
            throw new EntityNotFoundException("CertificatePublisher", "Id", id);

        return mapper.Map<CertificatePublisherDto>(certificatePublisher);
    }

    public async Task<Guid> Create(CertificatePublisherForCreationDto certificatePublisherDto)
    {
        var certificatePublisher = mapper.Map<CertificatePublisher>(certificatePublisherDto);
        return await repositoryManager.CertificatePublisher.Create(certificatePublisher);
    }

    public async Task Update(Guid id, CertificatePublisherForUpdateDto certificatePublisherDto)
    {
        var certificatePublisher = await repositoryManager.CertificatePublisher.FindById(id);
        if (certificatePublisher is null)
            throw new EntityNotFoundException("CertificatePublisher", "Id", id);

        mapper.Map(certificatePublisherDto, certificatePublisher);
        certificatePublisher.Id = id;
        await repositoryManager.CertificatePublisher.Update(certificatePublisher);
    }

    public async Task Delete(Guid id)
    {
        var certificatePublisher = await repositoryManager.CertificatePublisher.FindById(id);
        if (certificatePublisher is null)
            throw new EntityNotFoundException("CertificatePublisher", "Id", id);

        await repositoryManager.CertificatePublisher.Delete(id);
    }
}
