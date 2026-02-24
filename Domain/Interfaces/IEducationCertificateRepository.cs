using Domain.Models;

namespace Domain.Interfaces;

public interface IEducationCertificateRepository
{
    Task<IEnumerable<EducationCertificate>> FindAll();
    Task<EducationCertificate?> FindById(Guid id);
    Task<Guid> Create(EducationCertificate educationCertificate);
    Task Update(EducationCertificate educationCertificate);
    Task Delete(Guid id);
}
