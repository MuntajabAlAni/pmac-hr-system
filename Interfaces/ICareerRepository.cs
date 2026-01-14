using Entities.Models;

namespace Interfaces;

public interface ICareerRepository
{
    Task<Career_Tbl?> FindByEmployeeId(int employeeId);
    Task<Career_Tbl?> FindById(int id);
    Task<int> Create(Career_Tbl career);
    Task Update(Career_Tbl career);
    Task Delete(int id);
}
