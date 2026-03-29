using Domain.Entities.Organizations;

namespace Domain.Interfaces;

public interface IDepartmentRepository
{
    Task<IEnumerable<Department>> FindAll();
    Task<IEnumerable<Department>> FindByDirectorateId(Guid directorateId);
    Task<Department?> FindById(Guid id);
    Task<Guid> Create(Department department);
    Task Update(Department department);
    Task Delete(Guid id);
}
