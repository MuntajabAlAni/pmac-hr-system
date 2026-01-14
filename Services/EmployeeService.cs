using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
using Interfaces;
using Services.Interfaces;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Services;

public class EmployeeService(IRepositoryManager repositoryManager, IMapper mapper) : IEmployeeService
{
    public async Task<EmployeeDetailsDto> GetById(int id)
    {
        var employee = await repositoryManager.Employee.FindById(id);
        
        if (employee is null)
            throw new EntityNotFoundException("Employee", "Id", id);
        
        return mapper.Map<EmployeeDetailsDto>(employee);
    }

    public async Task<(IEnumerable<EmployeeDto> employees, int totalCount)> GetAll(PaginationParameters parameters)
    {
        var (employees, count) = await repositoryManager.Employee.FindByParameters(parameters);
        var employeeDtos = mapper.Map<IEnumerable<EmployeeDto>>(employees);
        
        return (employeeDtos, count);
    }

    public async Task<(IEnumerable<EmployeeDto> employees, int totalCount)> Search(string searchTerm, PaginationParameters parameters)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return await GetAll(parameters);
        
        var (employees, count) = await repositoryManager.Employee.Search(searchTerm, parameters);
        var employeeDtos = mapper.Map<IEnumerable<EmployeeDto>>(employees);
        
        return (employeeDtos, count);
    }

    public async Task<int> Create(EmployeeForCreationDto employeeDto)
    {
        var employee = mapper.Map<Employee_Tbl>(employeeDto);
        
        // Set defaults
        employee.IsSelected = false;
        employee.IsSelected_Thanks = false;
        employee.IsSelected_Letters = false;
        
        var id = await repositoryManager.Employee.Create(employee);
        return id;
    }

    public async Task Update(int id, EmployeeForUpdateDto employeeDto)
    {
        var employee = await repositoryManager.Employee.FindById(id);
        
        if (employee is null)
            throw new EntityNotFoundException("Employee", "Id", id);
        
        mapper.Map(employeeDto, employee);
        employee.Emp_Id = id;
        
        await repositoryManager.Employee.Update(employee);
    }

    public async Task Delete(int id)
    {
        var employee = await repositoryManager.Employee.FindById(id);
        
        if (employee is null)
            throw new EntityNotFoundException("Employee", "Id", id);
        
        await repositoryManager.Employee.Delete(id);
    }
}
