using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class RewardRepository(DapperContext context) : IRewardRepository
{
    public async Task<IEnumerable<Reward>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<Reward>(RewardQueries.FindAllQuery);
    }

    public async Task<Reward?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Reward>(RewardQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<Guid> Create(Reward reward)
    {
        if (reward.Id == Guid.Empty)
            reward.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(RewardQueries.InsertQuery, reward);
        return reward.Id;
    }

    public async Task Update(Reward reward)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(RewardQueries.UpdateQuery, reward);
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(RewardQueries.DeleteQuery, new { Id = id });
    }
}
