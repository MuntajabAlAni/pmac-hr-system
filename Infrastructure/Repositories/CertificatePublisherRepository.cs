using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class CertificatePublisherRepository(DapperContext context) : ICertificatePublisherRepository
{
    public async Task<IEnumerable<CertificatePublisher>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<CertificatePublisher>(CertificatePublisherQueries.FindAllQuery);
    }

    public async Task<CertificatePublisher?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<CertificatePublisher>(CertificatePublisherQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<Guid> Create(CertificatePublisher certificatePublisher)
    {
        if (certificatePublisher.Id == Guid.Empty)
            certificatePublisher.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(CertificatePublisherQueries.InsertQuery, certificatePublisher);
        return certificatePublisher.Id;
    }

    public async Task Update(CertificatePublisher certificatePublisher)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(CertificatePublisherQueries.UpdateQuery, certificatePublisher);
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(CertificatePublisherQueries.DeleteQuery, new { Id = id });
    }
}
