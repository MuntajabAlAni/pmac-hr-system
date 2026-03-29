using AutoMapper;
using Domain.Exceptions;
using Domain.Entities.Employees;
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

    public async Task<Guid> Create(EmployeeForCreationDto dto)
    {
        // Use domain constructor (DDD)
        var employee = new Employee(
            employeeNumber: dto.EmployeeNumber,
            archiveNumber: dto.ArchiveNumber,
            firstName: dto.FirstName,
            gender: dto.Gender,
            religion: dto.Religion,
            ethnicity: dto.Ethnicity,
            hireDate: dto.HireDate,
            userGuid: Guid.Empty // System user
        );

        var id = await repositoryManager.Employee.Create(employee);
        return id;
    }

    public async Task Update(Guid id, EmployeeForUpdateDto dto)
    {
        var employee = await repositoryManager.Employee.FindById(id);

        if (employee is null)
            throw new EntityNotFoundException("Employee", "Id", id);

        // Use domain methods for updates
        if (dto.HireDate.HasValue)
        {
            employee.UpdateHireInfo(
                dto.HireDate.Value,
                dto.HireBookNumber,
                dto.HireBookDate,
                dto.HireBookFilePath,
                dto.StartWorkDate,
                dto.StartWorkBookDate,
                dto.StartWorkBookFilePath,
                Guid.Empty
            );
        }

        if (dto.SpecialEmpStatus.HasValue)
            employee.UpdateSpecialEmpStatus(dto.SpecialEmpStatus.Value, Guid.Empty);

        if (dto.Status.HasValue)
            employee.ChangeStatus(dto.Status.Value, Guid.Empty);

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
