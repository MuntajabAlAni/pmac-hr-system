using Domain.Models;

namespace Domain.Interfaces;

public interface IAdministrativeActionRepository
{
    Task<IEnumerable<AdministrativeAction>> FindAll();
    Task<AdministrativeAction?> FindById(Guid id);
    Task<IEnumerable<AdministrativeAction>> FindByEmployeeId(Guid employeeId);
    Task<Guid> Create(AdministrativeAction administrativeAction);
    Task Update(AdministrativeAction administrativeAction);
    Task Delete(Guid id);
}
