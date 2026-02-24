using Domain.Models;

namespace Domain.Interfaces;

public interface IServiceContinuationRepository
{
    Task<IEnumerable<ServiceContinuation>> FindAll();
    Task<ServiceContinuation?> FindById(Guid id);
    Task<Guid> Create(ServiceContinuation serviceContinuation);
    Task Update(ServiceContinuation serviceContinuation);
    Task Delete(Guid id);
}
