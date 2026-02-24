using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class DepartmentService(IRepositoryManager repositoryManager, IMapper mapper) : IDepartmentService
{
    public async Task<IEnumerable<DepartmentDto>> GetAll()
    {
        var departments = await repositoryManager.Department.FindAll();
        return mapper.Map<IEnumerable<DepartmentDto>>(departments);
    }

    public async Task<IEnumerable<DepartmentDto>> GetByDirectorateId(Guid directorateId)
    {
        var departments = await repositoryManager.Department.FindByDirectorateId(directorateId);
        return mapper.Map<IEnumerable<DepartmentDto>>(departments);
    }

    public async Task<DepartmentDto> GetById(Guid id)
    {
        var department = await repositoryManager.Department.FindById(id);
        if (department is null)
            throw new EntityNotFoundException("Department", "Id", id);

        return mapper.Map<DepartmentDto>(department);
    }

    public async Task<Guid> Create(DepartmentForCreationDto departmentDto)
    {
        var department = mapper.Map<Department>(departmentDto);
        return await repositoryManager.Department.Create(department);
    }

    public async Task Update(Guid id, DepartmentForUpdateDto departmentDto)
    {
        var department = await repositoryManager.Department.FindById(id);
        if (department is null)
            throw new EntityNotFoundException("Department", "Id", id);

        mapper.Map(departmentDto, department);
        department.Id = id;
        await repositoryManager.Department.Update(department);
    }

    public async Task Delete(Guid id)
    {
        var department = await repositoryManager.Department.FindById(id);
        if (department is null)
            throw new EntityNotFoundException("Department", "Id", id);

        await repositoryManager.Department.Delete(id);
    }
}
