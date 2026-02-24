using Domain.Models;

namespace Domain.Interfaces;

public interface IVacationTotalRepository
{
    Task<IEnumerable<VacationTotal>> FindAll();
    Task<VacationTotal?> FindById(Guid id);
    Task<VacationTotal?> FindByEmployeeId(Guid employeeId);
    Task<Guid> Create(VacationTotal vacationTotal);
    Task Update(VacationTotal vacationTotal);
    Task Delete(Guid id);
}
