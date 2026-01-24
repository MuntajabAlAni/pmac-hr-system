using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;
using Domain.RequestFeatures;

namespace Infrastructure;

public class EmployeeRepository(DapperContext context) : IEmployeeRepository
{
    public async Task<Employee_Tbl?> FindById(int id)
    {
        const string query = EmployeeQueries.FindByIdQuery;
        
        using var connection = context.CreateConnection();
        connection.Open();
        
        var employee = await connection.QueryFirstOrDefaultAsync<Employee_Tbl>(query, new { Id = id });
        return employee;
    }

    public async Task<(IEnumerable<Employee_Tbl>, int)> FindByParameters(PaginationParameters parameters)
    {
        const string query = EmployeeQueries.FindAllQuery;
        const string countQuery = EmployeeQueries.CountQuery;
        
        var skip = (parameters.PageNumber - 1) * parameters.PageSize;
        var param = new
        {
            Skip = skip,
            PageSize = parameters.PageSize
        };
        
        using var connection = context.CreateConnection();
        connection.Open();
        
        var count = await connection.QueryFirstOrDefaultAsync<int>(countQuery);
        var employees = await connection.QueryAsync<Employee_Tbl>(query, param);
        
        return (employees, count);
    }

    public async Task<(IEnumerable<Employee_Tbl>, int)> Search(string searchTerm, PaginationParameters parameters)
    {
        const string query = EmployeeQueries.SearchQuery;
        const string countQuery = EmployeeQueries.CountQuery;
        
        var skip = (parameters.PageNumber - 1) * parameters.PageSize;
        var param = new
        {
            SearchTerm = searchTerm,
            Skip = skip,
            PageSize = parameters.PageSize
        };
        
        using var connection = context.CreateConnection();
        connection.Open();
        
        var count = await connection.QueryFirstOrDefaultAsync<int>(countQuery);
        var employees = await connection.QueryAsync<Employee_Tbl>(query, param);
        
        return (employees, count);
    }

    public async Task<int> Create(Employee_Tbl employee)
    {
        const string query = EmployeeQueries.InsertQuery;
        
        using var connection = context.CreateConnection();
        connection.Open();
        
        var id = await connection.QueryFirstAsync<int>(query, employee);
        return id;
    }

    public async Task Update(Employee_Tbl employee)
    {
        const string query = EmployeeQueries.UpdateQuery;
        
        using var connection = context.CreateConnection();
        connection.Open();
        
        await connection.ExecuteAsync(query, employee);
    }

    public async Task Delete(int id)
    {
        const string query = EmployeeQueries.DeleteQuery;
        
        using var connection = context.CreateConnection();
        connection.Open();
        
        await connection.ExecuteAsync(query, new { Id = id });
    }
}
