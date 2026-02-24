using Domain.Models;

namespace Domain.Interfaces;

public interface IWorkCareerTypeRepository
{
    Task<IEnumerable<WorkCareerType>> FindAll();
    Task<WorkCareerType?> FindById(Guid id);
    Task<Guid> Create(WorkCareerType workCareerType);
    Task Update(WorkCareerType workCareerType);
    Task Delete(Guid id);
}
