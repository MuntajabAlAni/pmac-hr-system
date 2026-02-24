using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class ServiceContinuationRepository(DapperContext context) : IServiceContinuationRepository
{
    public async Task<IEnumerable<ServiceContinuation>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<ServiceContinuation>(ServiceContinuationQueries.FindAllQuery);
    }

    public async Task<ServiceContinuation?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<ServiceContinuation>(ServiceContinuationQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<Guid> Create(ServiceContinuation serviceContinuation)
    {
        if (serviceContinuation.Id == Guid.Empty)
            serviceContinuation.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(ServiceContinuationQueries.InsertQuery, serviceContinuation);
        return serviceContinuation.Id;
    }

    public async Task Update(ServiceContinuation serviceContinuation)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(ServiceContinuationQueries.UpdateQuery, serviceContinuation);
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(ServiceContinuationQueries.DeleteQuery, new { Id = id });
    }
}
