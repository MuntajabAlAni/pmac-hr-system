using Domain.Models;

namespace Domain.Interfaces;

public interface IRankRepository
{
    Task<IEnumerable<Rank>> FindAll();
    Task<Rank?> FindById(Guid id);
    Task<Guid> Create(Rank rank);
    Task Update(Rank rank);
    Task Delete(Guid id);
}
