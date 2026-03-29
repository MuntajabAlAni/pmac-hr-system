using Dapper;
using Domain.Entities.EmploymentStructure;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class GradeRepository(DapperContext context) : IGradeRepository
{
    public async Task<IEnumerable<Grade>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<Grade>(GradeQueries.FindAllQuery);
    }

    public async Task<Grade?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Grade>(GradeQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<Guid> Create(Grade grade)
    {
        if (grade.Id == Guid.Empty)
            grade.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(GradeQueries.InsertQuery, new
        {
            grade.Id,
            grade.GradeName,
            grade.GradeLevel
        });
        return grade.Id;
    }

    public async Task Update(Grade grade)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(GradeQueries.UpdateQuery, new
        {
            grade.Id,
            grade.GradeName,
            grade.GradeLevel
        });
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(GradeQueries.DeleteQuery, new { Id = id });
    }
}
