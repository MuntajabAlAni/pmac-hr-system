using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface IDeligationService
{
    Task<IEnumerable<DeligationDto>> GetAll();
    Task<DeligationDto> GetById(Guid id);
    Task<Guid> Create(DeligationForCreationDto deligationDto);
    Task Update(Guid id, DeligationForUpdateDto deligationDto);
    Task Delete(Guid id);
}
