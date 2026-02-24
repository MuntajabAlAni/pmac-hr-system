using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class FingerPrintExceptionTypeRepository(DapperContext context) : IFingerPrintExceptionTypeRepository
{
    public async Task<IEnumerable<FingerPrintExceptionType>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<FingerPrintExceptionType>(FingerPrintExceptionTypeQueries.FindAllQuery);
    }

    public async Task<FingerPrintExceptionType?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<FingerPrintExceptionType>(FingerPrintExceptionTypeQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<Guid> Create(FingerPrintExceptionType fingerPrintExceptionType)
    {
        if (fingerPrintExceptionType.Id == Guid.Empty)
            fingerPrintExceptionType.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(FingerPrintExceptionTypeQueries.InsertQuery, fingerPrintExceptionType);
        return fingerPrintExceptionType.Id;
    }

    public async Task Update(FingerPrintExceptionType fingerPrintExceptionType)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(FingerPrintExceptionTypeQueries.UpdateQuery, fingerPrintExceptionType);
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(FingerPrintExceptionTypeQueries.DeleteQuery, new { Id = id });
    }
}
