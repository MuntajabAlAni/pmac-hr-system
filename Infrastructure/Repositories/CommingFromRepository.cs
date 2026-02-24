using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class CommingFromRepository(DapperContext context) : ICommingFromRepository
{
    public async Task<IEnumerable<CommingFrom>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<CommingFrom>(CommingFromQueries.FindAllQuery);
    }

    public async Task<CommingFrom?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<CommingFrom>(CommingFromQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<Guid> Create(CommingFrom commingFrom)
    {
        if (commingFrom.Id == Guid.Empty)
            commingFrom.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(CommingFromQueries.InsertQuery, commingFrom);
        return commingFrom.Id;
    }

    public async Task Update(CommingFrom commingFrom)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(CommingFromQueries.UpdateQuery, commingFrom);
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(CommingFromQueries.DeleteQuery, new { Id = id });
    }
}
