using Domain.Models;
using Domain.RequestFeatures;

namespace Domain.Interfaces;

public interface IEmployeeRepository
{
    Task<Employee?> FindById(Guid id);
    Task<(IEnumerable<Employee>, int)> FindByParameters(PaginationParameters parameters);
    Task<(IEnumerable<Employee>, int)> Search(string searchTerm, PaginationParameters parameters);
    Task<Guid> Create(Employee employee);
    Task Update(Employee employee);
    Task Delete(Guid id);
}
