using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class WorkCareerTypeService(IRepositoryManager repositoryManager, IMapper mapper) : IWorkCareerTypeService
{
    public async Task<IEnumerable<WorkCareerTypeDto>> GetAll()
    {
        var workCareerTypes = await repositoryManager.WorkCareerType.FindAll();
        return mapper.Map<IEnumerable<WorkCareerTypeDto>>(workCareerTypes);
    }

    public async Task<WorkCareerTypeDto> GetById(Guid id)
    {
        var workCareerType = await repositoryManager.WorkCareerType.FindById(id);
        if (workCareerType is null)
            throw new EntityNotFoundException("WorkCareerType", "Id", id);

        return mapper.Map<WorkCareerTypeDto>(workCareerType);
    }

    public async Task<Guid> Create(WorkCareerTypeForCreationDto workCareerTypeDto)
    {
        var workCareerType = mapper.Map<WorkCareerType>(workCareerTypeDto);
        return await repositoryManager.WorkCareerType.Create(workCareerType);
    }

    public async Task Update(Guid id, WorkCareerTypeForUpdateDto workCareerTypeDto)
    {
        var workCareerType = await repositoryManager.WorkCareerType.FindById(id);
        if (workCareerType is null)
            throw new EntityNotFoundException("WorkCareerType", "Id", id);

        mapper.Map(workCareerTypeDto, workCareerType);
        workCareerType.Id = id;
        await repositoryManager.WorkCareerType.Update(workCareerType);
    }

    public async Task Delete(Guid id)
    {
        var workCareerType = await repositoryManager.WorkCareerType.FindById(id);
        if (workCareerType is null)
            throw new EntityNotFoundException("WorkCareerType", "Id", id);

        await repositoryManager.WorkCareerType.Delete(id);
    }
}
