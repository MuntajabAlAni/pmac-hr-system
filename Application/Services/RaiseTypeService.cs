using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class RaiseTypeService(IRepositoryManager repositoryManager, IMapper mapper) : IRaiseTypeService
{
    public async Task<IEnumerable<RaiseTypeDto>> GetAll()
    {
        var raiseTypes = await repositoryManager.RaiseType.FindAll();
        return mapper.Map<IEnumerable<RaiseTypeDto>>(raiseTypes);
    }

    public async Task<RaiseTypeDto> GetById(Guid id)
    {
        var raiseType = await repositoryManager.RaiseType.FindById(id);
        if (raiseType is null)
            throw new EntityNotFoundException("RaiseType", "Id", id);

        return mapper.Map<RaiseTypeDto>(raiseType);
    }

    public async Task<Guid> Create(RaiseTypeForCreationDto raiseTypeDto)
    {
        var raiseType = mapper.Map<RaiseType>(raiseTypeDto);
        return await repositoryManager.RaiseType.Create(raiseType);
    }

    public async Task Update(Guid id, RaiseTypeForUpdateDto raiseTypeDto)
    {
        var raiseType = await repositoryManager.RaiseType.FindById(id);
        if (raiseType is null)
            throw new EntityNotFoundException("RaiseType", "Id", id);

        mapper.Map(raiseTypeDto, raiseType);
        raiseType.Id = id;
        await repositoryManager.RaiseType.Update(raiseType);
    }

    public async Task Delete(Guid id)
    {
        var raiseType = await repositoryManager.RaiseType.FindById(id);
        if (raiseType is null)
            throw new EntityNotFoundException("RaiseType", "Id", id);

        await repositoryManager.RaiseType.Delete(id);
    }
}
