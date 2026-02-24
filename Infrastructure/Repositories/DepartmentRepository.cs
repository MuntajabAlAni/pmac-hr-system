using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class DepartmentRepository(DapperContext context) : IDepartmentRepository
{
    public async Task<IEnumerable<Department>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<Department>(DepartmentQueries.FindAllQuery);
    }

    public async Task<IEnumerable<Department>> FindByDirectorateId(Guid directorateId)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<Department>(DepartmentQueries.FindByDirectorateIdQuery, new { DirectorateId = directorateId });
    }

    public async Task<Department?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Department>(DepartmentQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<Guid> Create(Department department)
    {
        if (department.Id == Guid.Empty)
            department.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(DepartmentQueries.InsertQuery, department);
        return department.Id;
    }

    public async Task Update(Department department)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(DepartmentQueries.UpdateQuery, department);
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(DepartmentQueries.DeleteQuery, new { Id = id });
    }
}
