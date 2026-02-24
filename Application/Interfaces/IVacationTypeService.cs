using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface IVacationTypeService
{
    Task<IEnumerable<VacationTypeDto>> GetAll();
    Task<VacationTypeDto> GetById(Guid id);
    Task<Guid> Create(VacationTypeForCreationDto vacationTypeDto);
    Task Update(Guid id, VacationTypeForUpdateDto vacationTypeDto);
    Task Delete(Guid id);
}
