using Entities.Models;

namespace Interfaces;

public interface IDepartmentRepository
{
    Task<IEnumerable<Department_tbl>> FindAll();
    Task<IEnumerable<Department_tbl>> FindByDirectorateId(int directorateId);
    Task<Department_tbl?> FindById(int id);
    Task<int> Create(Department_tbl department);
    Task Update(Department_tbl department);
    Task Delete(int id);
}
