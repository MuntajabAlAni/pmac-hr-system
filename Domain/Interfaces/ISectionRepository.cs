using Domain.Models;

namespace Domain.Interfaces;

public interface ISectionRepository
{
    Task<IEnumerable<Section>> FindAll();
    Task<IEnumerable<Section>> FindByDepartmentId(int departmentId);
    Task<Section?> FindById(Guid id);
    Task<int> Create(Section section);
    Task Update(Section section);
    Task Delete(Guid id);
}
