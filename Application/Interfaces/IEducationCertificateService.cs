using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface IEducationCertificateService
{
    Task<IEnumerable<EducationCertificateDto>> GetAll();
    Task<EducationCertificateDto> GetById(Guid id);
    Task<Guid> Create(EducationCertificateForCreationDto educationCertificateDto);
    Task Update(Guid id, EducationCertificateForUpdateDto educationCertificateDto);
    Task Delete(Guid id);
}
