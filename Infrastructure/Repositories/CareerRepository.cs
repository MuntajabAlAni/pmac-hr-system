using Dapper;
using Domain.Entities.Career;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class CareerRepository(DapperContext context) : ICareerRepository
{
    public async Task<IEnumerable<Career>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<Career>(CareerQueries.FindAllQuery);
    }

    public async Task<Career?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Career>(CareerQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<IEnumerable<Career>> FindByEmployeeId(Guid employeeId)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<Career>(CareerQueries.FindByEmployeeIdQuery, new { EmployeeId = employeeId });
    }

    public async Task<Guid> Create(Career career)
    {
        if (career.Id == Guid.Empty)
            career.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(CareerQueries.InsertQuery, new
        {
            Id = career.Id,
            career.EmployeeId,
            career.MovementDate,
            career.MovementType,
            career.Notes,
            career.AuthorityName,
            career.SubAuthorityName,
            career.DirectorateName,
            career.SubDirectorateName,
            career.DepartmentName,
            career.SectionName,
            career.UnitName,
            career.JobTitle,
            career.GradeName,
            career.BasicSalary
        });
        return career.Id;
    }

    public async Task Update(Career career)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(CareerQueries.UpdateQuery, new
        {
            Id = career.Id,
            career.Notes
        });
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(CareerQueries.DeleteQuery, new { Id = id });
    }
}
