using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class RankRepository(DapperContext context) : IRankRepository
{
    public async Task<IEnumerable<Rank>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<Rank>(RankQueries.FindAllQuery);
    }

    public async Task<Rank?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Rank>(RankQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<Guid> Create(Rank rank)
    {
        if (rank.Id == Guid.Empty)
            rank.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(RankQueries.InsertQuery, rank);
        return rank.Id;
    }

    public async Task Update(Rank rank)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(RankQueries.UpdateQuery, rank);
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(RankQueries.DeleteQuery, new { Id = id });
    }
}
