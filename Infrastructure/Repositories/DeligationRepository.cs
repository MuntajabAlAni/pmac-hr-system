using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class DeligationRepository(DapperContext context) : IDeligationRepository
{
    public async Task<IEnumerable<Deligation>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<Deligation>(DeligationQueries.FindAllQuery);
    }

    public async Task<Deligation?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Deligation>(DeligationQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<Guid> Create(Deligation deligation)
    {
        if (deligation.Id == Guid.Empty)
            deligation.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(DeligationQueries.InsertQuery, deligation);
        return deligation.Id;
    }

    public async Task Update(Deligation deligation)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(DeligationQueries.UpdateQuery, deligation);
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(DeligationQueries.DeleteQuery, new { Id = id });
    }
}
