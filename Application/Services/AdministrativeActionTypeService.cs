using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class AdministrativeActionTypeService(IRepositoryManager repositoryManager, IMapper mapper) : IAdministrativeActionTypeService
{
    public async Task<IEnumerable<AdministrativeActionTypeDto>> GetAll()
    {
        var types = await repositoryManager.AdministrativeActionType.FindAll();
        return mapper.Map<IEnumerable<AdministrativeActionTypeDto>>(types);
    }

    public async Task<AdministrativeActionTypeDto> GetById(Guid id)
    {
        var type = await repositoryManager.AdministrativeActionType.FindById(id);
        if (type is null)
            throw new EntityNotFoundException("AdministrativeActionType", "Id", id);

        return mapper.Map<AdministrativeActionTypeDto>(type);
    }

    public async Task<Guid> Create(AdministrativeActionTypeForCreationDto administrativeActionTypeDto)
    {
        var type = mapper.Map<AdministrativeActionType>(administrativeActionTypeDto);
        return await repositoryManager.AdministrativeActionType.Create(type);
    }

    public async Task Update(Guid id, AdministrativeActionTypeForUpdateDto administrativeActionTypeDto)
    {
        var type = await repositoryManager.AdministrativeActionType.FindById(id);
        if (type is null)
            throw new EntityNotFoundException("AdministrativeActionType", "Id", id);

        mapper.Map(administrativeActionTypeDto, type);
        type.Id = id;
        await repositoryManager.AdministrativeActionType.Update(type);
    }

    public async Task Delete(Guid id)
    {
        var type = await repositoryManager.AdministrativeActionType.FindById(id);
        if (type is null)
            throw new EntityNotFoundException("AdministrativeActionType", "Id", id);

        await repositoryManager.AdministrativeActionType.Delete(id);
    }
}
