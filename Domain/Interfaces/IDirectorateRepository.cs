using Domain.Models;

namespace Domain.Interfaces;

public interface IDirectorateRepository
{
    Task<IEnumerable<Directorate>> FindAll();
    Task<Directorate?> FindById(Guid id);
    Task<Guid> Create(Directorate directorate);
    Task Update(Directorate directorate);
    Task Delete(Guid id);
}
