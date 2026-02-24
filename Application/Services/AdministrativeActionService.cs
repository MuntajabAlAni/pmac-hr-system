using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class AdministrativeActionService(IRepositoryManager repositoryManager, IMapper mapper) : IAdministrativeActionService
{
    public async Task<IEnumerable<AdministrativeActionDto>> GetAll()
    {
        var actions = await repositoryManager.AdministrativeAction.FindAll();
        return mapper.Map<IEnumerable<AdministrativeActionDto>>(actions);
    }

    public async Task<AdministrativeActionDto> GetById(Guid id)
    {
        var action = await repositoryManager.AdministrativeAction.FindById(id);
        if (action is null)
            throw new EntityNotFoundException("AdministrativeAction", "Id", id);

        return mapper.Map<AdministrativeActionDto>(action);
    }

    public async Task<IEnumerable<AdministrativeActionDto>> GetByEmployeeId(Guid employeeId)
    {
        var actions = await repositoryManager.AdministrativeAction.FindByEmployeeId(employeeId);
        return mapper.Map<IEnumerable<AdministrativeActionDto>>(actions);
    }

    public async Task<Guid> Create(AdministrativeActionForCreationDto administrativeActionDto)
    {
        var action = mapper.Map<AdministrativeAction>(administrativeActionDto);
        return await repositoryManager.AdministrativeAction.Create(action);
    }

    public async Task Update(Guid id, AdministrativeActionForUpdateDto administrativeActionDto)
    {
        var action = await repositoryManager.AdministrativeAction.FindById(id);
        if (action is null)
            throw new EntityNotFoundException("AdministrativeAction", "Id", id);

        mapper.Map(administrativeActionDto, action);
        action.Id = id;
        await repositoryManager.AdministrativeAction.Update(action);
    }

    public async Task Delete(Guid id)
    {
        var action = await repositoryManager.AdministrativeAction.FindById(id);
        if (action is null)
            throw new EntityNotFoundException("AdministrativeAction", "Id", id);

        await repositoryManager.AdministrativeAction.Delete(id);
    }
}
