using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class BasicSalaryRepository(DapperContext context) : IBasicSalaryRepository
{
    public async Task<IEnumerable<BasicSalary>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<BasicSalary>(BasicSalaryQueries.FindAllQuery);
    }

    public async Task<BasicSalary?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<BasicSalary>(BasicSalaryQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<Guid> Create(BasicSalary basicSalary)
    {
        if (basicSalary.Id == Guid.Empty)
            basicSalary.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(BasicSalaryQueries.InsertQuery, basicSalary);
        return basicSalary.Id;
    }

    public async Task Update(BasicSalary basicSalary)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(BasicSalaryQueries.UpdateQuery, basicSalary);
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(BasicSalaryQueries.DeleteQuery, new { Id = id });
    }
}
