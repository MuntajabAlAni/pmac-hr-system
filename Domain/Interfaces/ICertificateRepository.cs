using Domain.Models;

namespace Domain.Interfaces;

public interface ICertificateRepository
{
    Task<IEnumerable<Certificate>> FindAll();
    Task<Certificate?> FindById(Guid id);
    Task<Guid> Create(Certificate certificate);
    Task Update(Certificate certificate);
    Task Delete(Guid id);
}
