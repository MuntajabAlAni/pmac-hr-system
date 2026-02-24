using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class PositionRepository(DapperContext context) : IPositionRepository
{
    public async Task<IEnumerable<Position>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<Position>(PositionQueries.FindAllQuery);
    }

    public async Task<Position?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Position>(PositionQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<Guid> Create(Position position)
    {
        if (position.Id == Guid.Empty)
            position.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(PositionQueries.InsertQuery, position);
        return position.Id;
    }

    public async Task Update(Position position)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(PositionQueries.UpdateQuery, position);
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(PositionQueries.DeleteQuery, new { Id = id });
    }
}
