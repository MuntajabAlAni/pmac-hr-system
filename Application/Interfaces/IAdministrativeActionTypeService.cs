using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface IAdministrativeActionTypeService
{
    Task<IEnumerable<AdministrativeActionTypeDto>> GetAll();
    Task<AdministrativeActionTypeDto> GetById(Guid id);
    Task<Guid> Create(AdministrativeActionTypeForCreationDto administrativeActionTypeDto);
    Task Update(Guid id, AdministrativeActionTypeForUpdateDto administrativeActionTypeDto);
    Task Delete(Guid id);
}
