using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class RewardService(IRepositoryManager repositoryManager, IMapper mapper) : IRewardService
{
    public async Task<IEnumerable<RewardDto>> GetAll()
    {
        var rewards = await repositoryManager.Reward.FindAll();
        return mapper.Map<IEnumerable<RewardDto>>(rewards);
    }

    public async Task<RewardDto> GetById(Guid id)
    {
        var reward = await repositoryManager.Reward.FindById(id);
        if (reward is null)
            throw new EntityNotFoundException("Reward", "Id", id);

        return mapper.Map<RewardDto>(reward);
    }

    public async Task<Guid> Create(RewardForCreationDto rewardDto)
    {
        var reward = mapper.Map<Reward>(rewardDto);
        return await repositoryManager.Reward.Create(reward);
    }

    public async Task Update(Guid id, RewardForUpdateDto rewardDto)
    {
        var reward = await repositoryManager.Reward.FindById(id);
        if (reward is null)
            throw new EntityNotFoundException("Reward", "Id", id);

        mapper.Map(rewardDto, reward);
        reward.Id = id;
        await repositoryManager.Reward.Update(reward);
    }

    public async Task Delete(Guid id)
    {
        var reward = await repositoryManager.Reward.FindById(id);
        if (reward is null)
            throw new EntityNotFoundException("Reward", "Id", id);

        await repositoryManager.Reward.Delete(id);
    }
}
