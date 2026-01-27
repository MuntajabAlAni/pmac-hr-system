using Domain.Models;
using Domain.RequestFeatures;

namespace Domain.Interfaces;

public interface IEmployeeRepository
{
    Task<Employee?> FindById(int id);
    Task<(IEnumerable<Employee>, int)> FindByParameters(PaginationParameters parameters);
    Task<(IEnumerable<Employee>, int)> Search(string searchTerm, PaginationParameters parameters);
    Task<int> Create(Employee employee);
    Task Update(Employee employee);
    Task Delete(int id);
}
