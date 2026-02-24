using Domain.Models;

namespace Domain.Interfaces;

public interface IRaiseRepository
{
    Task<IEnumerable<Raise>> FindAll();
    Task<Raise?> FindById(Guid id);
    Task<IEnumerable<Raise>> FindByEmployeeId(Guid employeeId);
    Task<Guid> Create(Raise raise);
    Task Update(Raise raise);
    Task Delete(Guid id);
}
