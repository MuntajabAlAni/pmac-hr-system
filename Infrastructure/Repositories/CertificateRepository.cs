using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class CertificateRepository(DapperContext context) : ICertificateRepository
{
    public async Task<IEnumerable<Certificate>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<Certificate>(CertificateQueries.FindAllQuery);
    }

    public async Task<Certificate?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Certificate>(CertificateQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<Guid> Create(Certificate certificate)
    {
        if (certificate.Id == Guid.Empty)
            certificate.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(CertificateQueries.InsertQuery, certificate);
        return certificate.Id;
    }

    public async Task Update(Certificate certificate)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(CertificateQueries.UpdateQuery, certificate);
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(CertificateQueries.DeleteQuery, new { Id = id });
    }
}
