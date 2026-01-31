using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;
using Domain.RequestFeatures;

namespace Application.Services;

public class EmployeeService(IRepositoryManager repositoryManager, IMapper mapper) : IEmployeeService
{
    public async Task<EmployeeDetailsDto> GetById(Guid id)
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

    public async Task<Guid> Create(EmployeeForCreationDto employeeDto)
    {
        var employee = mapper.Map<Employee>(employeeDto);

        // Set defaults
        employee.IsSelected = false;
        employee.IsSelectedThanks = false;
        employee.IsSelectedLetters = false;

        var id = await repositoryManager.Employee.Create(employee);
        return id;
    }

    public async Task Update(Guid id, EmployeeForUpdateDto employeeDto)
    {
        var employee = await repositoryManager.Employee.FindById(id);

        if (employee is null)
            throw new EntityNotFoundException("Employee", "Id", id);

        mapper.Map(employeeDto, employee);
        employee.Id = id;

        await repositoryManager.Employee.Update(employee);
    }

    public async Task Delete(Guid id)
    {
        var employee = await repositoryManager.Employee.FindById(id);

        if (employee is null)
            throw new EntityNotFoundException("Employee", "Id", id);

        await repositoryManager.Employee.Delete(id);
    }
}
