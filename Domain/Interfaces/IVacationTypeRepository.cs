using Domain.Entities.Vacations;

namespace Domain.Interfaces;

public interface IVacationTypeRepository
{
    Task<IEnumerable<VacationType>> FindAll();
    Task<VacationType?> FindById(Guid id);
    Task<Guid> Create(VacationType vacationType);
    Task Update(VacationType vacationType);
    Task Delete(Guid id);
}
