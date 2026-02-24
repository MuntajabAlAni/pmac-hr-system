using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface IPersonalCardService
{
    Task<IEnumerable<PersonalCardDto>> GetAll();
    Task<PersonalCardDto> GetById(Guid id);
    Task<Guid> Create(PersonalCardForCreationDto personalCardDto);
    Task Update(Guid id, PersonalCardForUpdateDto personalCardDto);
    Task Delete(Guid id);
}
