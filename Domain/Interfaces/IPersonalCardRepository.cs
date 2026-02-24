using Domain.Models;

namespace Domain.Interfaces;

public interface IPersonalCardRepository
{
    Task<IEnumerable<PersonalCard>> FindAll();
    Task<PersonalCard?> FindById(Guid id);
    Task<Guid> Create(PersonalCard personalCard);
    Task Update(PersonalCard personalCard);
    Task Delete(Guid id);
}
