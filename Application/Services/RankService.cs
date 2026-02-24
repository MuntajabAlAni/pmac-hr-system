using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class RankService(IRepositoryManager repositoryManager, IMapper mapper) : IRankService
{
    public async Task<IEnumerable<RankDto>> GetAll()
    {
        var ranks = await repositoryManager.Rank.FindAll();
        return mapper.Map<IEnumerable<RankDto>>(ranks);
    }

    public async Task<RankDto> GetById(Guid id)
    {
        var rank = await repositoryManager.Rank.FindById(id);
        if (rank is null)
            throw new EntityNotFoundException("Rank", "Id", id);

        return mapper.Map<RankDto>(rank);
    }

    public async Task<Guid> Create(RankForCreationDto rankDto)
    {
        var rank = mapper.Map<Rank>(rankDto);
        return await repositoryManager.Rank.Create(rank);
    }

    public async Task Update(Guid id, RankForUpdateDto rankDto)
    {
        var rank = await repositoryManager.Rank.FindById(id);
        if (rank is null)
            throw new EntityNotFoundException("Rank", "Id", id);

        mapper.Map(rankDto, rank);
        rank.Id = id;
        await repositoryManager.Rank.Update(rank);
    }

    public async Task Delete(Guid id)
    {
        var rank = await repositoryManager.Rank.FindById(id);
        if (rank is null)
            throw new EntityNotFoundException("Rank", "Id", id);

        await repositoryManager.Rank.Delete(id);
    }
}
