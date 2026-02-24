using Domain.Models;

namespace Domain.Interfaces;

public interface ICommingFromRepository
{
    Task<IEnumerable<CommingFrom>> FindAll();
    Task<CommingFrom?> FindById(Guid id);
    Task<Guid> Create(CommingFrom commingFrom);
    Task Update(CommingFrom commingFrom);
    Task Delete(Guid id);
}
