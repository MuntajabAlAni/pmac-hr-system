using Dapper;
using Domain.Entities.Organizations;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class SectionRepository(DapperContext context) : ISectionRepository
{
    public async Task<IEnumerable<Section>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<Section>(SectionQueries.FindAllQuery);
    }

    public async Task<IEnumerable<Section>> FindByDepartmentId(Guid departmentId)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<Section>(SectionQueries.FindByDepartmentIdQuery, new { DepartmentId = departmentId });
    }

    public async Task<Section?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Section>(SectionQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<Guid> Create(Section section)
    {
        if (section.Id == Guid.Empty)
            section.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(SectionQueries.InsertQuery, new
        {
            section.Id,
            section.Name,
            section.HighAuthorityId,
            section.SubHighAuthorityId,
            section.DirectorateId,
            section.SubDirectorateId,
            section.DepartmentId
        });
        return section.Id;
    }

    public async Task Update(Section section)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(SectionQueries.UpdateQuery, new
        {
            section.Id,
            section.Name
        });
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(SectionQueries.DeleteQuery, new { Id = id });
    }
}
