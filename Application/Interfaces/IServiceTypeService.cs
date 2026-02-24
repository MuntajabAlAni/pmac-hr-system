using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface IServiceTypeService
{
    Task<IEnumerable<ServiceTypeDto>> GetAll();
    Task<ServiceTypeDto> GetById(Guid id);
    Task<Guid> Create(ServiceTypeForCreationDto serviceTypeDto);
    Task Update(Guid id, ServiceTypeForUpdateDto serviceTypeDto);
    Task Delete(Guid id);
}
