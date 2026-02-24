using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class VacationRepository(DapperContext context) : IVacationRepository
{
    public async Task<IEnumerable<Vacation>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<Vacation>(VacationQueries.FindAllQuery);
    }

    public async Task<Vacation?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Vacation>(VacationQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<IEnumerable<Vacation>> FindByEmployeeId(Guid employeeId)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<Vacation>(VacationQueries.FindByEmployeeIdQuery, new { EmployeeId = employeeId });
    }

    public async Task<Guid> Create(Vacation vacation)
    {
        if (vacation.Id == Guid.Empty)
            vacation.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(VacationQueries.InsertQuery, vacation);
        return vacation.Id;
    }

    public async Task Update(Vacation vacation)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(VacationQueries.UpdateQuery, vacation);
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(VacationQueries.DeleteQuery, new { Id = id });
    }
}
