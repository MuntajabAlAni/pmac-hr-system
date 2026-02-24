using Domain.Models;

namespace Domain.Interfaces;

public interface IStoreEmployeeRepository
{
    Task<IEnumerable<StoreEmployee>> FindAll();
    Task<StoreEmployee?> FindById(Guid id);
    Task<Guid> Create(StoreEmployee storeEmployee);
    Task Update(StoreEmployee storeEmployee);
    Task Delete(Guid id);
}
