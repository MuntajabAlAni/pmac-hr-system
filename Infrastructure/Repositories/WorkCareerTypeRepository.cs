using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class WorkCareerTypeRepository(DapperContext context) : IWorkCareerTypeRepository
{
    public async Task<IEnumerable<WorkCareerType>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<WorkCareerType>(WorkCareerTypeQueries.FindAllQuery);
    }

    public async Task<WorkCareerType?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<WorkCareerType>(WorkCareerTypeQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<Guid> Create(WorkCareerType workCareerType)
    {
        if (workCareerType.Id == Guid.Empty)
            workCareerType.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(WorkCareerTypeQueries.InsertQuery, workCareerType);
        return workCareerType.Id;
    }

    public async Task Update(WorkCareerType workCareerType)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(WorkCareerTypeQueries.UpdateQuery, workCareerType);
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(WorkCareerTypeQueries.DeleteQuery, new { Id = id });
    }
}
