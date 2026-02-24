using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class RaiseTypeRepository(DapperContext context) : IRaiseTypeRepository
{
    public async Task<IEnumerable<RaiseType>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<RaiseType>(RaiseTypeQueries.FindAllQuery);
    }

    public async Task<RaiseType?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<RaiseType>(RaiseTypeQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<Guid> Create(RaiseType raiseType)
    {
        if (raiseType.Id == Guid.Empty)
            raiseType.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(RaiseTypeQueries.InsertQuery, raiseType);
        return raiseType.Id;
    }

    public async Task Update(RaiseType raiseType)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(RaiseTypeQueries.UpdateQuery, raiseType);
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(RaiseTypeQueries.DeleteQuery, new { Id = id });
    }
}
