using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class StoreEmployeeRepository(DapperContext context) : IStoreEmployeeRepository
{
    public async Task<IEnumerable<StoreEmployee>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<StoreEmployee>(StoreEmployeeQueries.FindAllQuery);
    }

    public async Task<StoreEmployee?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<StoreEmployee>(StoreEmployeeQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<Guid> Create(StoreEmployee storeEmployee)
    {
        if (storeEmployee.Id == Guid.Empty)
            storeEmployee.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(StoreEmployeeQueries.InsertQuery, storeEmployee);
        return storeEmployee.Id;
    }

    public async Task Update(StoreEmployee storeEmployee)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(StoreEmployeeQueries.UpdateQuery, storeEmployee);
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(StoreEmployeeQueries.DeleteQuery, new { Id = id });
    }
}
