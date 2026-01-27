using Domain.Models;

namespace Domain.Interfaces;

public interface IDepartmentRepository
{
    Task<IEnumerable<Department>> FindAll();
    Task<IEnumerable<Department>> FindByDirectorateId(int directorateId);
    Task<Department?> FindById(int id);
    Task<int> Create(Department department);
    Task Update(Department department);
    Task Delete(int id);
}
