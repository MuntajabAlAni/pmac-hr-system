using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface IServiceContinuationService
{
    Task<IEnumerable<ServiceContinuationDto>> GetAll();
    Task<ServiceContinuationDto> GetById(Guid id);
    Task<Guid> Create(ServiceContinuationForCreationDto serviceContinuationDto);
    Task Update(Guid id, ServiceContinuationForUpdateDto serviceContinuationDto);
    Task Delete(Guid id);
}
