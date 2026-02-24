using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class CertificateService(IRepositoryManager repositoryManager, IMapper mapper) : ICertificateService
{
    public async Task<IEnumerable<CertificateDto>> GetAll()
    {
        var certificates = await repositoryManager.Certificate.FindAll();
        return mapper.Map<IEnumerable<CertificateDto>>(certificates);
    }

    public async Task<CertificateDto> GetById(Guid id)
    {
        var certificate = await repositoryManager.Certificate.FindById(id);
        if (certificate is null)
            throw new EntityNotFoundException("Certificate", "Id", id);

        return mapper.Map<CertificateDto>(certificate);
    }

    public async Task<Guid> Create(CertificateForCreationDto certificateDto)
    {
        var certificate = mapper.Map<Certificate>(certificateDto);
        return await repositoryManager.Certificate.Create(certificate);
    }

    public async Task Update(Guid id, CertificateForUpdateDto certificateDto)
    {
        var certificate = await repositoryManager.Certificate.FindById(id);
        if (certificate is null)
            throw new EntityNotFoundException("Certificate", "Id", id);

        mapper.Map(certificateDto, certificate);
        certificate.Id = id;
        await repositoryManager.Certificate.Update(certificate);
    }

    public async Task Delete(Guid id)
    {
        var certificate = await repositoryManager.Certificate.FindById(id);
        if (certificate is null)
            throw new EntityNotFoundException("Certificate", "Id", id);

        await repositoryManager.Certificate.Delete(id);
    }
}
