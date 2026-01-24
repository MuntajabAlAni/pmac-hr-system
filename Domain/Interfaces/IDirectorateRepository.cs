using Domain.Models;

namespace Domain.Interfaces;

public interface IDirectorateRepository
{
    Task<IEnumerable<Directorate_tbl>> FindAll();
    Task<Directorate_tbl?> FindById(int id);
    Task<int> Create(Directorate_tbl directorate);
    Task Update(Directorate_tbl directorate);
    Task Delete(int id);
}
