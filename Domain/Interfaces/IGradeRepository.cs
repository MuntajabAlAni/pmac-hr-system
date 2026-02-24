using Domain.Models;

namespace Domain.Interfaces;

public interface IGradeRepository
{
    Task<IEnumerable<Grade>> FindAll();
    Task<Grade?> FindById(Guid id);
    Task<Guid> Create(Grade grade);
    Task Update(Grade grade);
    Task Delete(Guid id);
}
