using Domain.Models;

namespace Domain.Interfaces;

public interface IAdministrativeActionTypeRepository
{
    Task<IEnumerable<AdministrativeActionType>> FindAll();
    Task<AdministrativeActionType?> FindById(Guid id);
    Task<Guid> Create(AdministrativeActionType administrativeActionType);
    Task Update(AdministrativeActionType administrativeActionType);
    Task Delete(Guid id);
}
