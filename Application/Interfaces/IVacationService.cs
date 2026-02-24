using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface IVacationService
{
    Task<IEnumerable<VacationDto>> GetAll();
    Task<VacationDto> GetById(Guid id);
    Task<IEnumerable<VacationDto>> GetByEmployeeId(Guid employeeId);
    Task<Guid> Create(VacationForCreationDto vacationDto);
    Task Update(Guid id, VacationForUpdateDto vacationDto);
    Task Delete(Guid id);
}
