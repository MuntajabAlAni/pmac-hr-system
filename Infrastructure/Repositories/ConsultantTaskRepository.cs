using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class ConsultantTaskRepository(DapperContext context) : IConsultantTaskRepository
{
    public async Task<IEnumerable<ConsultantTask>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<ConsultantTask>(ConsultantTaskQueries.FindAllQuery);
    }

    public async Task<ConsultantTask?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<ConsultantTask>(ConsultantTaskQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<Guid> Create(ConsultantTask consultantTask)
    {
        if (consultantTask.Id == Guid.Empty)
            consultantTask.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(ConsultantTaskQueries.InsertQuery, consultantTask);
        return consultantTask.Id;
    }

    public async Task Update(ConsultantTask consultantTask)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(ConsultantTaskQueries.UpdateQuery, consultantTask);
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(ConsultantTaskQueries.DeleteQuery, new { Id = id });
    }
}
