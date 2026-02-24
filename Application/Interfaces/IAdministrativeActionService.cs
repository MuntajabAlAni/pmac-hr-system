using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface IAdministrativeActionService
{
    Task<IEnumerable<AdministrativeActionDto>> GetAll();
    Task<AdministrativeActionDto> GetById(Guid id);
    Task<IEnumerable<AdministrativeActionDto>> GetByEmployeeId(Guid employeeId);
    Task<Guid> Create(AdministrativeActionForCreationDto administrativeActionDto);
    Task Update(Guid id, AdministrativeActionForUpdateDto administrativeActionDto);
    Task Delete(Guid id);
}
