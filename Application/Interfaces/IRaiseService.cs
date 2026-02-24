using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface IRaiseService
{
    Task<IEnumerable<RaiseDto>> GetAll();
    Task<RaiseDto> GetById(Guid id);
    Task<IEnumerable<RaiseDto>> GetByEmployeeId(Guid employeeId);
    Task<Guid> Create(RaiseForCreationDto raiseDto);
    Task Update(Guid id, RaiseForUpdateDto raiseDto);
    Task Delete(Guid id);
}
