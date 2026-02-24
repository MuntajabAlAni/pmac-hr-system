using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class LogFileRepository(DapperContext context) : ILogFileRepository
{
    public async Task<IEnumerable<LogFile>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<LogFile>(LogFileQueries.FindAllQuery);
    }

    public async Task<LogFile?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<LogFile>(LogFileQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<Guid> Create(LogFile logFile)
    {
        if (logFile.Id == Guid.Empty)
            logFile.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(LogFileQueries.InsertQuery, logFile);
        return logFile.Id;
    }
}
