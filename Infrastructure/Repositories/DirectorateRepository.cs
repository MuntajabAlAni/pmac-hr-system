using Dapper;
using Domain.Entities.Organizations;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class DirectorateRepository(DapperContext context) : IDirectorateRepository
{
    public async Task<IEnumerable<Directorate>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<Directorate>(DirectorateQueries.FindAllQuery);
    }

    public async Task<Directorate?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Directorate>(DirectorateQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<Guid> Create(Directorate directorate)
    {
        if (directorate.Id == Guid.Empty)
            directorate.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(DirectorateQueries.InsertQuery, new
        {
            directorate.Id,
            directorate.Name,
            directorate.HighAuthorityId,
            directorate.SubHighAuthorityId
        });
        return directorate.Id;
    }

    public async Task Update(Directorate directorate)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(DirectorateQueries.UpdateQuery, new
        {
            directorate.Id,
            directorate.Name
        });
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(DirectorateQueries.DeleteQuery, new { Id = id });
    }
}
