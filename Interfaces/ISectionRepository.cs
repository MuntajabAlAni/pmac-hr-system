using Entities.Models;

namespace Interfaces;

public interface ISectionRepository
{
    Task<IEnumerable<Section_tbl>> FindAll();
    Task<IEnumerable<Section_tbl>> FindByDepartmentId(int departmentId);
    Task<Section_tbl?> FindById(int id);
    Task<int> Create(Section_tbl section);
    Task Update(Section_tbl section);
    Task Delete(int id);
}
