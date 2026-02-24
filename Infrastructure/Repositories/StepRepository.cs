using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class StepRepository(DapperContext context) : IStepRepository
{
    public async Task<IEnumerable<Step>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<Step>(StepQueries.FindAllQuery);
    }

    public async Task<Step?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Step>(StepQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<Guid> Create(Step step)
    {
        if (step.Id == Guid.Empty)
            step.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(StepQueries.InsertQuery, step);
        return step.Id;
    }

    public async Task Update(Step step)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(StepQueries.UpdateQuery, step);
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(StepQueries.DeleteQuery, new { Id = id });
    }
}
