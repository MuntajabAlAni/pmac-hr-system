using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class OfficialDocumentTypeRepository(DapperContext context) : IOfficialDocumentTypeRepository
{
    public async Task<IEnumerable<OfficialDocumentType>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<OfficialDocumentType>(OfficialDocumentTypeQueries.FindAllQuery);
    }

    public async Task<OfficialDocumentType?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<OfficialDocumentType>(OfficialDocumentTypeQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<Guid> Create(OfficialDocumentType officialDocumentType)
    {
        if (officialDocumentType.Id == Guid.Empty)
            officialDocumentType.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(OfficialDocumentTypeQueries.InsertQuery, officialDocumentType);
        return officialDocumentType.Id;
    }

    public async Task Update(OfficialDocumentType officialDocumentType)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(OfficialDocumentTypeQueries.UpdateQuery, officialDocumentType);
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(OfficialDocumentTypeQueries.DeleteQuery, new { Id = id });
    }
}
