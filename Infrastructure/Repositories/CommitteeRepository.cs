using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class CommitteeRepository(DapperContext context) : ICommitteeRepository
{
    public async Task<IEnumerable<Committee>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<Committee>(CommitteeQueries.FindAllQuery);
    }

    public async Task<Committee?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Committee>(CommitteeQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<Guid> Create(Committee committee)
    {
        if (committee.Id == Guid.Empty)
            committee.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(CommitteeQueries.InsertQuery, committee);
        return committee.Id;
    }

    public async Task Update(Committee committee)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(CommitteeQueries.UpdateQuery, committee);
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(CommitteeQueries.DeleteQuery, new { Id = id });
    }
}
