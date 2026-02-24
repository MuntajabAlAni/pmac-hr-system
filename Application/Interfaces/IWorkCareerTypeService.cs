using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface IWorkCareerTypeService
{
    Task<IEnumerable<WorkCareerTypeDto>> GetAll();
    Task<WorkCareerTypeDto> GetById(Guid id);
    Task<Guid> Create(WorkCareerTypeForCreationDto workCareerTypeDto);
    Task Update(Guid id, WorkCareerTypeForUpdateDto workCareerTypeDto);
    Task Delete(Guid id);
}
