using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class VacationTypeRepository(DapperContext context) : IVacationTypeRepository
{
    public async Task<IEnumerable<VacationType>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<VacationType>(VacationTypeQueries.FindAllQuery);
    }

    public async Task<VacationType?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<VacationType>(VacationTypeQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<Guid> Create(VacationType vacationType)
    {
        if (vacationType.Id == Guid.Empty)
            vacationType.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(VacationTypeQueries.InsertQuery, vacationType);
        return vacationType.Id;
    }

    public async Task Update(VacationType vacationType)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(VacationTypeQueries.UpdateQuery, vacationType);
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(VacationTypeQueries.DeleteQuery, new { Id = id });
    }
}
