using Domain.Models;

namespace Domain.Interfaces;

public interface IVacationRepository
{
    Task<IEnumerable<Vacation>> FindAll();
    Task<Vacation?> FindById(Guid id);
    Task<IEnumerable<Vacation>> FindByEmployeeId(Guid employeeId);
    Task<Guid> Create(Vacation vacation);
    Task Update(Vacation vacation);
    Task Delete(Guid id);
}
