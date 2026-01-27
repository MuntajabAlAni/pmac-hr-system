using Domain.Models;

namespace Domain.Interfaces;

public interface IDirectorateRepository
{
    Task<IEnumerable<Directorate>> FindAll();
    Task<Directorate?> FindById(int id);
    Task<int> Create(Directorate directorate);
    Task Update(Directorate directorate);
    Task Delete(int id);
}
