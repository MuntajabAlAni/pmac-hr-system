using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class AdministrativeActionTypeRepository(DapperContext context) : IAdministrativeActionTypeRepository
{
    public async Task<IEnumerable<AdministrativeActionType>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<AdministrativeActionType>(AdministrativeActionTypeQueries.FindAllQuery);
    }

    public async Task<AdministrativeActionType?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<AdministrativeActionType>(AdministrativeActionTypeQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<Guid> Create(AdministrativeActionType administrativeActionType)
    {
        if (administrativeActionType.Id == Guid.Empty)
            administrativeActionType.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(AdministrativeActionTypeQueries.InsertQuery, administrativeActionType);
        return administrativeActionType.Id;
    }

    public async Task Update(AdministrativeActionType administrativeActionType)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(AdministrativeActionTypeQueries.UpdateQuery, administrativeActionType);
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(AdministrativeActionTypeQueries.DeleteQuery, new { Id = id });
    }
}
