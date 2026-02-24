using Domain.Models;

namespace Domain.Interfaces;

public interface ICertificatePublisherRepository
{
    Task<IEnumerable<CertificatePublisher>> FindAll();
    Task<CertificatePublisher?> FindById(Guid id);
    Task<Guid> Create(CertificatePublisher certificatePublisher);
    Task Update(CertificatePublisher certificatePublisher);
    Task Delete(Guid id);
}
