using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class CommingFromService(IRepositoryManager repositoryManager, IMapper mapper) : ICommingFromService
{
    public async Task<IEnumerable<CommingFromDto>> GetAll()
    {
        var commingFroms = await repositoryManager.CommingFrom.FindAll();
        return mapper.Map<IEnumerable<CommingFromDto>>(commingFroms);
    }

    public async Task<CommingFromDto> GetById(Guid id)
    {
        var commingFrom = await repositoryManager.CommingFrom.FindById(id);
        if (commingFrom is null)
            throw new EntityNotFoundException("CommingFrom", "Id", id);

        return mapper.Map<CommingFromDto>(commingFrom);
    }

    public async Task<Guid> Create(CommingFromForCreationDto commingFromDto)
    {
        var commingFrom = mapper.Map<CommingFrom>(commingFromDto);
        return await repositoryManager.CommingFrom.Create(commingFrom);
    }

    public async Task Update(Guid id, CommingFromForUpdateDto commingFromDto)
    {
        var commingFrom = await repositoryManager.CommingFrom.FindById(id);
        if (commingFrom is null)
            throw new EntityNotFoundException("CommingFrom", "Id", id);

        mapper.Map(commingFromDto, commingFrom);
        commingFrom.Id = id;
        await repositoryManager.CommingFrom.Update(commingFrom);
    }

    public async Task Delete(Guid id)
    {
        var commingFrom = await repositoryManager.CommingFrom.FindById(id);
        if (commingFrom is null)
            throw new EntityNotFoundException("CommingFrom", "Id", id);

        await repositoryManager.CommingFrom.Delete(id);
    }
}
