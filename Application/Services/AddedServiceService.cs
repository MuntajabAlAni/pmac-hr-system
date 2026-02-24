using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class AddedServiceService(IRepositoryManager repositoryManager, IMapper mapper) : IAddedServiceService
{
    public async Task<IEnumerable<AddedServiceDto>> GetAll()
    {
        var addedServices = await repositoryManager.AddedService.FindAll();
        return mapper.Map<IEnumerable<AddedServiceDto>>(addedServices);
    }

    public async Task<AddedServiceDto> GetById(Guid id)
    {
        var addedService = await repositoryManager.AddedService.FindById(id);
        if (addedService is null)
            throw new EntityNotFoundException("AddedService", "Id", id);

        return mapper.Map<AddedServiceDto>(addedService);
    }

    public async Task<Guid> Create(AddedServiceForCreationDto addedServiceDto)
    {
        var addedService = mapper.Map<AddedService>(addedServiceDto);
        return await repositoryManager.AddedService.Create(addedService);
    }

    public async Task Update(Guid id, AddedServiceForUpdateDto addedServiceDto)
    {
        var addedService = await repositoryManager.AddedService.FindById(id);
        if (addedService is null)
            throw new EntityNotFoundException("AddedService", "Id", id);

        mapper.Map(addedServiceDto, addedService);
        addedService.Id = id;
        await repositoryManager.AddedService.Update(addedService);
    }

    public async Task Delete(Guid id)
    {
        var addedService = await repositoryManager.AddedService.FindById(id);
        if (addedService is null)
            throw new EntityNotFoundException("AddedService", "Id", id);

        await repositoryManager.AddedService.Delete(id);
    }
}
