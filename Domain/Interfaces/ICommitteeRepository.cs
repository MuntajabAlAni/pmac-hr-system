using Domain.Models;

namespace Domain.Interfaces;

public interface ICommitteeRepository
{
    Task<IEnumerable<Committee>> FindAll();
    Task<Committee?> FindById(Guid id);
    Task<Guid> Create(Committee committee);
    Task Update(Committee committee);
    Task Delete(Guid id);
}
