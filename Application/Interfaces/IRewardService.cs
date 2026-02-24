using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface IRewardService
{
    Task<IEnumerable<RewardDto>> GetAll();
    Task<RewardDto> GetById(Guid id);
    Task<Guid> Create(RewardForCreationDto rewardDto);
    Task Update(Guid id, RewardForUpdateDto rewardDto);
    Task Delete(Guid id);
}
