using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface ICertificateService
{
    Task<IEnumerable<CertificateDto>> GetAll();
    Task<CertificateDto> GetById(Guid id);
    Task<Guid> Create(CertificateForCreationDto certificateDto);
    Task Update(Guid id, CertificateForUpdateDto certificateDto);
    Task Delete(Guid id);
}
