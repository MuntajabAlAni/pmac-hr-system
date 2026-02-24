using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class OfficialDocumentRepository(DapperContext context) : IOfficialDocumentRepository
{
    public async Task<IEnumerable<OfficialDocument>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<OfficialDocument>(OfficialDocumentQueries.FindAllQuery);
    }

    public async Task<OfficialDocument?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<OfficialDocument>(OfficialDocumentQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<Guid> Create(OfficialDocument officialDocument)
    {
        if (officialDocument.Id == Guid.Empty)
            officialDocument.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(OfficialDocumentQueries.InsertQuery, officialDocument);
        return officialDocument.Id;
    }

    public async Task Update(OfficialDocument officialDocument)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(OfficialDocumentQueries.UpdateQuery, officialDocument);
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(OfficialDocumentQueries.DeleteQuery, new { Id = id });
    }
}
