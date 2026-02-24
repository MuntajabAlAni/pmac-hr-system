using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class TaskStatusRepository(DapperContext context) : ITaskStatusRepository
{
    public async Task<IEnumerable<Domain.Models.TaskStatus>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<Domain.Models.TaskStatus>(TaskStatusQueries.FindAllQuery);
    }

    public async Task<Domain.Models.TaskStatus?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Domain.Models.TaskStatus>(TaskStatusQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<Guid> Create(Domain.Models.TaskStatus taskStatus)
    {
        if (taskStatus.Id == Guid.Empty)
            taskStatus.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(TaskStatusQueries.InsertQuery, taskStatus);
        return taskStatus.Id;
    }

    public async Task Update(Domain.Models.TaskStatus taskStatus)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(TaskStatusQueries.UpdateQuery, taskStatus);
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(TaskStatusQueries.DeleteQuery, new { Id = id });
    }
}
