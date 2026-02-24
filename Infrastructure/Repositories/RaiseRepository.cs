using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class RaiseRepository(DapperContext context) : IRaiseRepository
{
    public async Task<IEnumerable<Raise>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<Raise>(RaiseQueries.FindAllQuery);
    }

    public async Task<Raise?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Raise>(RaiseQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<IEnumerable<Raise>> FindByEmployeeId(Guid employeeId)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<Raise>(RaiseQueries.FindByEmployeeIdQuery, new { EmployeeId = employeeId });
    }

    public async Task<Guid> Create(Raise raise)
    {
        if (raise.Id == Guid.Empty)
            raise.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(RaiseQueries.InsertQuery, raise);
        return raise.Id;
    }

    public async Task Update(Raise raise)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(RaiseQueries.UpdateQuery, raise);
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(RaiseQueries.DeleteQuery, new { Id = id });
    }
}
