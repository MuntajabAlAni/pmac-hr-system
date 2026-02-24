using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class CommitteeService(IRepositoryManager repositoryManager, IMapper mapper) : ICommitteeService
{
    public async Task<IEnumerable<CommitteeDto>> GetAll()
    {
        var committees = await repositoryManager.Committee.FindAll();
        return mapper.Map<IEnumerable<CommitteeDto>>(committees);
    }

    public async Task<CommitteeDto> GetById(Guid id)
    {
        var committee = await repositoryManager.Committee.FindById(id);
        if (committee is null)
            throw new EntityNotFoundException("Committee", "Id", id);

        return mapper.Map<CommitteeDto>(committee);
    }

    public async Task<Guid> Create(CommitteeForCreationDto committeeDto)
    {
        var committee = mapper.Map<Committee>(committeeDto);
        return await repositoryManager.Committee.Create(committee);
    }

    public async Task Update(Guid id, CommitteeForUpdateDto committeeDto)
    {
        var committee = await repositoryManager.Committee.FindById(id);
        if (committee is null)
            throw new EntityNotFoundException("Committee", "Id", id);

        mapper.Map(committeeDto, committee);
        committee.Id = id;
        await repositoryManager.Committee.Update(committee);
    }

    public async Task Delete(Guid id)
    {
        var committee = await repositoryManager.Committee.FindById(id);
        if (committee is null)
            throw new EntityNotFoundException("Committee", "Id", id);

        await repositoryManager.Committee.Delete(id);
    }
}
