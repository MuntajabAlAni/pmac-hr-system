using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface IPositionService
{
    Task<IEnumerable<PositionDto>> GetAll();
    Task<PositionDto> GetById(Guid id);
    Task<Guid> Create(PositionForCreationDto positionDto);
    Task Update(Guid id, PositionForUpdateDto positionDto);
    Task Delete(Guid id);
}
