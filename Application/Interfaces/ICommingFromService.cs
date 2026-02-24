using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface ICommingFromService
{
    Task<IEnumerable<CommingFromDto>> GetAll();
    Task<CommingFromDto> GetById(Guid id);
    Task<Guid> Create(CommingFromForCreationDto commingFromDto);
    Task Update(Guid id, CommingFromForUpdateDto commingFromDto);
    Task Delete(Guid id);
}
