using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface ICertificatePublisherService
{
    Task<IEnumerable<CertificatePublisherDto>> GetAll();
    Task<CertificatePublisherDto> GetById(Guid id);
    Task<Guid> Create(CertificatePublisherForCreationDto certificatePublisherDto);
    Task Update(Guid id, CertificatePublisherForUpdateDto certificatePublisherDto);
    Task Delete(Guid id);
}
