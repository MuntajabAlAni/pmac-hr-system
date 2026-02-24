using Domain.Models;

namespace Domain.Interfaces;

public interface IStepRepository
{
    Task<IEnumerable<Step>> FindAll();
    Task<Step?> FindById(Guid id);
    Task<Guid> Create(Step step);
    Task Update(Step step);
    Task Delete(Guid id);
}
