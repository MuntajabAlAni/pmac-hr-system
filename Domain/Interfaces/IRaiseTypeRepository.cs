using Domain.Models;

namespace Domain.Interfaces;

public interface IRaiseTypeRepository
{
    Task<IEnumerable<RaiseType>> FindAll();
    Task<RaiseType?> FindById(Guid id);
    Task<Guid> Create(RaiseType raiseType);
    Task Update(RaiseType raiseType);
    Task Delete(Guid id);
}
