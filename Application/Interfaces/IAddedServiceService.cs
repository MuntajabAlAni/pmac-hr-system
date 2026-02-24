using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface IAddedServiceService
{
    Task<IEnumerable<AddedServiceDto>> GetAll();
    Task<AddedServiceDto> GetById(Guid id);
    Task<Guid> Create(AddedServiceForCreationDto addedServiceDto);
    Task Update(Guid id, AddedServiceForUpdateDto addedServiceDto);
    Task Delete(Guid id);
}
