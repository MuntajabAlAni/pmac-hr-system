using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class EducationCertificateRepository(DapperContext context) : IEducationCertificateRepository
{
    public async Task<IEnumerable<EducationCertificate>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<EducationCertificate>(EducationCertificateQueries.FindAllQuery);
    }

    public async Task<EducationCertificate?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<EducationCertificate>(EducationCertificateQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<Guid> Create(EducationCertificate educationCertificate)
    {
        if (educationCertificate.Id == Guid.Empty)
            educationCertificate.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(EducationCertificateQueries.InsertQuery, educationCertificate);
        return educationCertificate.Id;
    }

    public async Task Update(EducationCertificate educationCertificate)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(EducationCertificateQueries.UpdateQuery, educationCertificate);
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(EducationCertificateQueries.DeleteQuery, new { Id = id });
    }
}
