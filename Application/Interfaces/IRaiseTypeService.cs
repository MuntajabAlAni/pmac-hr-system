using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface IRaiseTypeService
{
    Task<IEnumerable<RaiseTypeDto>> GetAll();
    Task<RaiseTypeDto> GetById(Guid id);
    Task<Guid> Create(RaiseTypeForCreationDto raiseTypeDto);
    Task Update(Guid id, RaiseTypeForUpdateDto raiseTypeDto);
    Task Delete(Guid id);
}
