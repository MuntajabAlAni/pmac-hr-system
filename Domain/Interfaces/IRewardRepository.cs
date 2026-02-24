using Domain.Models;

namespace Domain.Interfaces;

public interface IRewardRepository
{
    Task<IEnumerable<Reward>> FindAll();
    Task<Reward?> FindById(Guid id);
    Task<Guid> Create(Reward reward);
    Task Update(Reward reward);
    Task Delete(Guid id);
}
