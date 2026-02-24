using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class EducationCertificateService(IRepositoryManager repositoryManager, IMapper mapper) : IEducationCertificateService
{
    public async Task<IEnumerable<EducationCertificateDto>> GetAll()
    {
        var certificates = await repositoryManager.EducationCertificate.FindAll();
        return mapper.Map<IEnumerable<EducationCertificateDto>>(certificates);
    }

    public async Task<EducationCertificateDto> GetById(Guid id)
    {
        var certificate = await repositoryManager.EducationCertificate.FindById(id);
        if (certificate is null)
            throw new EntityNotFoundException("EducationCertificate", "Id", id);

        return mapper.Map<EducationCertificateDto>(certificate);
    }

    public async Task<Guid> Create(EducationCertificateForCreationDto educationCertificateDto)
    {
        var certificate = mapper.Map<EducationCertificate>(educationCertificateDto);
        return await repositoryManager.EducationCertificate.Create(certificate);
    }

    public async Task Update(Guid id, EducationCertificateForUpdateDto educationCertificateDto)
    {
        var certificate = await repositoryManager.EducationCertificate.FindById(id);
        if (certificate is null)
            throw new EntityNotFoundException("EducationCertificate", "Id", id);

        mapper.Map(educationCertificateDto, certificate);
        certificate.Id = id;
        await repositoryManager.EducationCertificate.Update(certificate);
    }

    public async Task Delete(Guid id)
    {
        var certificate = await repositoryManager.EducationCertificate.FindById(id);
        if (certificate is null)
            throw new EntityNotFoundException("EducationCertificate", "Id", id);

        await repositoryManager.EducationCertificate.Delete(id);
    }
}
