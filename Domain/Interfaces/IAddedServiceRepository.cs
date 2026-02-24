using Domain.Models;

namespace Domain.Interfaces;

public interface IAddedServiceRepository
{
    Task<IEnumerable<AddedService>> FindAll();
    Task<AddedService?> FindById(Guid id);
    Task<Guid> Create(AddedService addedService);
    Task Update(AddedService addedService);
    Task Delete(Guid id);
}
