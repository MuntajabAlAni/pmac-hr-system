using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class AddedServiceRepository(DapperContext context) : IAddedServiceRepository
{
    public async Task<IEnumerable<AddedService>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<AddedService>(AddedServiceQueries.FindAllQuery);
    }

    public async Task<AddedService?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<AddedService>(AddedServiceQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<Guid> Create(AddedService addedService)
    {
        if (addedService.Id == Guid.Empty)
            addedService.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(AddedServiceQueries.InsertQuery, addedService);
        return addedService.Id;
    }

    public async Task Update(AddedService addedService)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(AddedServiceQueries.UpdateQuery, addedService);
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(AddedServiceQueries.DeleteQuery, new { Id = id });
    }
}
