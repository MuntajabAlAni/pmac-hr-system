using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class MaritalStatusRepository(DapperContext context) : IMaritalStatusRepository
{
    public async Task<IEnumerable<MaritalStatus>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<MaritalStatus>(MaritalStatusQueries.FindAllQuery);
    }

    public async Task<MaritalStatus?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<MaritalStatus>(MaritalStatusQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<Guid> Create(MaritalStatus maritalStatus)
    {
        if (maritalStatus.Id == Guid.Empty)
            maritalStatus.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(MaritalStatusQueries.InsertQuery, maritalStatus);
        return maritalStatus.Id;
    }

    public async Task Update(MaritalStatus maritalStatus)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(MaritalStatusQueries.UpdateQuery, maritalStatus);
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(MaritalStatusQueries.DeleteQuery, new { Id = id });
    }
}
