using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface IStepService
{
    Task<IEnumerable<StepDto>> GetAll();
    Task<StepDto> GetById(Guid id);
    Task<Guid> Create(StepForCreationDto stepDto);
    Task Update(Guid id, StepForUpdateDto stepDto);
    Task Delete(Guid id);
}
