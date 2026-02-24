using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface IMaritalStatusService
{
    Task<IEnumerable<MaritalStatusDto>> GetAll();
    Task<MaritalStatusDto> GetById(Guid id);
    Task<Guid> Create(MaritalStatusForCreationDto maritalStatusDto);
    Task Update(Guid id, MaritalStatusForUpdateDto maritalStatusDto);
    Task Delete(Guid id);
}
