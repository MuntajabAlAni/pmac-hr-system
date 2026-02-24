using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class ServiceTypeRepository(DapperContext context) : IServiceTypeRepository
{
    public async Task<IEnumerable<ServiceType>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<ServiceType>(ServiceTypeQueries.FindAllQuery);
    }

    public async Task<ServiceType?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<ServiceType>(ServiceTypeQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<Guid> Create(ServiceType serviceType)
    {
        if (serviceType.Id == Guid.Empty)
            serviceType.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(ServiceTypeQueries.InsertQuery, serviceType);
        return serviceType.Id;
    }

    public async Task Update(ServiceType serviceType)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(ServiceTypeQueries.UpdateQuery, serviceType);
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(ServiceTypeQueries.DeleteQuery, new { Id = id });
    }
}
