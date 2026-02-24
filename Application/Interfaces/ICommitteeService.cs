using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface ICommitteeService
{
    Task<IEnumerable<CommitteeDto>> GetAll();
    Task<CommitteeDto> GetById(Guid id);
    Task<Guid> Create(CommitteeForCreationDto committeeDto);
    Task Update(Guid id, CommitteeForUpdateDto committeeDto);
    Task Delete(Guid id);
}
