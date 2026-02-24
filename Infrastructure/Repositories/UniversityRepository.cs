using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class UniversityRepository(DapperContext context) : IUniversityRepository
{
    public async Task<IEnumerable<University>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<University>(UniversityQueries.FindAllQuery);
    }

    public async Task<University?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<University>(UniversityQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<Guid> Create(University university)
    {
        if (university.Id == Guid.Empty)
            university.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(UniversityQueries.InsertQuery, university);
        return university.Id;
    }

    public async Task Update(University university)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(UniversityQueries.UpdateQuery, university);
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(UniversityQueries.DeleteQuery, new { Id = id });
    }
}
