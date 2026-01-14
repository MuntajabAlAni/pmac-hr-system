using Entities.Models;
using Shared.RequestFeatures;

namespace Interfaces;

public interface IEmployeeRepository
{
    Task<Employee_Tbl?> FindById(int id);
    Task<(IEnumerable<Employee_Tbl>, int)> FindByParameters(PaginationParameters parameters);
    Task<(IEnumerable<Employee_Tbl>, int)> Search(string searchTerm, PaginationParameters parameters);
    Task<int> Create(Employee_Tbl employee);
    Task Update(Employee_Tbl employee);
    Task Delete(int id);
}
