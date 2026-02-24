using Domain.Models;

namespace Domain.Interfaces;

public interface IUniversityRepository
{
    Task<IEnumerable<University>> FindAll();
    Task<University?> FindById(Guid id);
    Task<Guid> Create(University university);
    Task Update(University university);
    Task Delete(Guid id);
}
