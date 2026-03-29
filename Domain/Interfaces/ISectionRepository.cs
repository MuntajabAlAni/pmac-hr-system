using Domain.Entities.Organizations;

namespace Domain.Interfaces;

public interface ISectionRepository
{
    Task<IEnumerable<Section>> FindAll();
    Task<IEnumerable<Section>> FindByDepartmentId(Guid departmentId);
    Task<Section?> FindById(Guid id);
    Task<Guid> Create(Section section);
    Task Update(Section section);
    Task Delete(Guid id);
}
