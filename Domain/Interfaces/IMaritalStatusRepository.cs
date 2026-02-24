using Domain.Models;

namespace Domain.Interfaces;

public interface IMaritalStatusRepository
{
    Task<IEnumerable<MaritalStatus>> FindAll();
    Task<MaritalStatus?> FindById(Guid id);
    Task<Guid> Create(MaritalStatus maritalStatus);
    Task Update(MaritalStatus maritalStatus);
    Task Delete(Guid id);
}
