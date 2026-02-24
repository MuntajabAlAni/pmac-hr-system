using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class MaritalStatusService(IRepositoryManager repositoryManager, IMapper mapper) : IMaritalStatusService
{
    public async Task<IEnumerable<MaritalStatusDto>> GetAll()
    {
        var maritalStatuses = await repositoryManager.MaritalStatus.FindAll();
        return mapper.Map<IEnumerable<MaritalStatusDto>>(maritalStatuses);
    }

    public async Task<MaritalStatusDto> GetById(Guid id)
    {
        var maritalStatus = await repositoryManager.MaritalStatus.FindById(id);
        if (maritalStatus is null)
            throw new EntityNotFoundException("MaritalStatus", "Id", id);

        return mapper.Map<MaritalStatusDto>(maritalStatus);
    }

    public async Task<Guid> Create(MaritalStatusForCreationDto maritalStatusDto)
    {
        var maritalStatus = mapper.Map<MaritalStatus>(maritalStatusDto);
        return await repositoryManager.MaritalStatus.Create(maritalStatus);
    }

    public async Task Update(Guid id, MaritalStatusForUpdateDto maritalStatusDto)
    {
        var maritalStatus = await repositoryManager.MaritalStatus.FindById(id);
        if (maritalStatus is null)
            throw new EntityNotFoundException("MaritalStatus", "Id", id);

        mapper.Map(maritalStatusDto, maritalStatus);
        maritalStatus.Id = id;
        await repositoryManager.MaritalStatus.Update(maritalStatus);
    }

    public async Task Delete(Guid id)
    {
        var maritalStatus = await repositoryManager.MaritalStatus.FindById(id);
        if (maritalStatus is null)
            throw new EntityNotFoundException("MaritalStatus", "Id", id);

        await repositoryManager.MaritalStatus.Delete(id);
    }
}
