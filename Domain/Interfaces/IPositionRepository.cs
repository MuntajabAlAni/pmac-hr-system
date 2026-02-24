using Domain.Models;

namespace Domain.Interfaces;

public interface IPositionRepository
{
    Task<IEnumerable<Position>> FindAll();
    Task<Position?> FindById(Guid id);
    Task<Guid> Create(Position position);
    Task Update(Position position);
    Task Delete(Guid id);
}
