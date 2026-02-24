using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface IStoreEmployeeService
{
    Task<IEnumerable<StoreEmployeeDto>> GetAll();
    Task<StoreEmployeeDto> GetById(Guid id);
    Task<Guid> Create(StoreEmployeeForCreationDto storeEmployeeDto);
    Task Update(Guid id, StoreEmployeeForUpdateDto storeEmployeeDto);
    Task Delete(Guid id);
}
