using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class StoreEmployeeService(IRepositoryManager repositoryManager, IMapper mapper) : IStoreEmployeeService
{
    public async Task<IEnumerable<StoreEmployeeDto>> GetAll()
    {
        var storeEmployees = await repositoryManager.StoreEmployee.FindAll();
        return mapper.Map<IEnumerable<StoreEmployeeDto>>(storeEmployees);
    }

    public async Task<StoreEmployeeDto> GetById(Guid id)
    {
        var storeEmployee = await repositoryManager.StoreEmployee.FindById(id);
        if (storeEmployee is null)
            throw new EntityNotFoundException("StoreEmployee", "Id", id);

        return mapper.Map<StoreEmployeeDto>(storeEmployee);
    }

    public async Task<Guid> Create(StoreEmployeeForCreationDto storeEmployeeDto)
    {
        var storeEmployee = mapper.Map<StoreEmployee>(storeEmployeeDto);
        return await repositoryManager.StoreEmployee.Create(storeEmployee);
    }

    public async Task Update(Guid id, StoreEmployeeForUpdateDto storeEmployeeDto)
    {
        var storeEmployee = await repositoryManager.StoreEmployee.FindById(id);
        if (storeEmployee is null)
            throw new EntityNotFoundException("StoreEmployee", "Id", id);

        mapper.Map(storeEmployeeDto, storeEmployee);
        storeEmployee.Id = id;
        await repositoryManager.StoreEmployee.Update(storeEmployee);
    }

    public async Task Delete(Guid id)
    {
        var storeEmployee = await repositoryManager.StoreEmployee.FindById(id);
        if (storeEmployee is null)
            throw new EntityNotFoundException("StoreEmployee", "Id", id);

        await repositoryManager.StoreEmployee.Delete(id);
    }
}
