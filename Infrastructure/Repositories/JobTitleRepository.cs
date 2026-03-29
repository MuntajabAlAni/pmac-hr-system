using Dapper;
using Domain.Entities.EmploymentStructure;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class JobTitleRepository(DapperContext context) : IJobTitleRepository
{
    public async Task<IEnumerable<JobTitle>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<JobTitle>(JobTitleQueries.FindAllQuery);
    }

    public async Task<JobTitle?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<JobTitle>(JobTitleQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<Guid> Create(JobTitle jobTitle)
    {
        if (jobTitle.Id == Guid.Empty)
            jobTitle.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(JobTitleQueries.InsertQuery, new
        {
            jobTitle.Id,
            jobTitle.Title,
            jobTitle.GradeId,
            jobTitle.JobTitleType
        });
        return jobTitle.Id;
    }

    public async Task Update(JobTitle jobTitle)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(JobTitleQueries.UpdateQuery, new
        {
            jobTitle.Id,
            jobTitle.Title,
            jobTitle.GradeId,
            jobTitle.JobTitleType
        });
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(JobTitleQueries.DeleteQuery, new { Id = id });
    }
}
