using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface IVacationTotalService
{
    Task<IEnumerable<VacationTotalDto>> GetAll();
    Task<VacationTotalDto> GetById(Guid id);
    Task<VacationTotalDto> GetByEmployeeId(Guid employeeId);
    Task<Guid> Create(VacationTotalForCreationDto vacationTotalDto);
    Task Update(Guid id, VacationTotalForUpdateDto vacationTotalDto);
    Task Delete(Guid id);
}
