using Domain.Models;

namespace Domain.Interfaces;

public interface IDeligationRepository
{
    Task<IEnumerable<Deligation>> FindAll();
    Task<Deligation?> FindById(Guid id);
    Task<Guid> Create(Deligation deligation);
    Task Update(Deligation deligation);
    Task Delete(Guid id);
}
