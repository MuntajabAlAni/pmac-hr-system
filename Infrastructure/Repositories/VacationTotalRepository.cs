using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class VacationTotalRepository(DapperContext context) : IVacationTotalRepository
{
    public async Task<IEnumerable<VacationTotal>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<VacationTotal>(VacationTotalQueries.FindAllQuery);
    }

    public async Task<VacationTotal?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<VacationTotal>(VacationTotalQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<VacationTotal?> FindByEmployeeId(Guid employeeId)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<VacationTotal>(VacationTotalQueries.FindByEmployeeIdQuery, new { EmployeeId = employeeId });
    }

    public async Task<Guid> Create(VacationTotal vacationTotal)
    {
        if (vacationTotal.Id == Guid.Empty)
            vacationTotal.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(VacationTotalQueries.InsertQuery, vacationTotal);
        return vacationTotal.Id;
    }

    public async Task Update(VacationTotal vacationTotal)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(VacationTotalQueries.UpdateQuery, vacationTotal);
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(VacationTotalQueries.DeleteQuery, new { Id = id });
    }
}
