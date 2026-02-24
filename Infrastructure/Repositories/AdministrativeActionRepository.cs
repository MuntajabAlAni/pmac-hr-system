using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class AdministrativeActionRepository(DapperContext context) : IAdministrativeActionRepository
{
    public async Task<IEnumerable<AdministrativeAction>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<AdministrativeAction>(AdministrativeActionQueries.FindAllQuery);
    }

    public async Task<AdministrativeAction?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<AdministrativeAction>(AdministrativeActionQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<IEnumerable<AdministrativeAction>> FindByEmployeeId(Guid employeeId)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<AdministrativeAction>(AdministrativeActionQueries.FindByEmployeeIdQuery, new { EmployeeId = employeeId });
    }

    public async Task<Guid> Create(AdministrativeAction administrativeAction)
    {
        if (administrativeAction.Id == Guid.Empty)
            administrativeAction.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(AdministrativeActionQueries.InsertQuery, administrativeAction);
        return administrativeAction.Id;
    }

    public async Task Update(AdministrativeAction administrativeAction)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(AdministrativeActionQueries.UpdateQuery, administrativeAction);
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(AdministrativeActionQueries.DeleteQuery, new { Id = id });
    }
}
