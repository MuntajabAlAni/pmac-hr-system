using Application.DataTransferObjects;
using Domain.RequestFeatures;

namespace Application.Interfaces;

public interface IEmployeeService
{
    Task<EmployeeDetailsDto> GetById(Guid id);
    Task<(IEnumerable<EmployeeDto> employees, int totalCount)> GetAll(PaginationParameters parameters);
    Task<(IEnumerable<EmployeeDto> employees, int totalCount)> Search(string searchTerm, PaginationParameters parameters);
    Task<Guid> Create(EmployeeForCreationDto employeeDto);
    Task Update(Guid id, EmployeeForUpdateDto employeeDto);
    Task Delete(Guid id);
}
