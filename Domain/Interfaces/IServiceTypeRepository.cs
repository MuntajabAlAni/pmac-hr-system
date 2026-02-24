using Domain.Models;

namespace Domain.Interfaces;

public interface IServiceTypeRepository
{
    Task<IEnumerable<ServiceType>> FindAll();
    Task<ServiceType?> FindById(Guid id);
    Task<Guid> Create(ServiceType serviceType);
    Task Update(ServiceType serviceType);
    Task Delete(Guid id);
}
