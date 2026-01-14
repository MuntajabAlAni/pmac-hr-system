using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Services.Interfaces;

public interface IEmployeeService
{
    Task<EmployeeDetailsDto> GetById(int id);
    Task<(IEnumerable<EmployeeDto> employees, int totalCount)> GetAll(PaginationParameters parameters);
    Task<(IEnumerable<EmployeeDto> employees, int totalCount)> Search(string searchTerm, PaginationParameters parameters);
    Task<int> Create(EmployeeForCreationDto employeeDto);
    Task Update(int id, EmployeeForUpdateDto employeeDto);
    Task Delete(int id);
}
