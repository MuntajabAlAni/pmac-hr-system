using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class PersonalCardRepository(DapperContext context) : IPersonalCardRepository
{
    public async Task<IEnumerable<PersonalCard>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<PersonalCard>(PersonalCardQueries.FindAllQuery);
    }

    public async Task<PersonalCard?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<PersonalCard>(PersonalCardQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<Guid> Create(PersonalCard personalCard)
    {
        if (personalCard.Id == Guid.Empty)
            personalCard.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(PersonalCardQueries.InsertQuery, personalCard);
        return personalCard.Id;
    }

    public async Task Update(PersonalCard personalCard)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(PersonalCardQueries.UpdateQuery, personalCard);
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(PersonalCardQueries.DeleteQuery, new { Id = id });
    }
}
