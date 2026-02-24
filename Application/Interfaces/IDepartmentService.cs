using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface IDepartmentService
{
    Task<IEnumerable<DepartmentDto>> GetAll();
    Task<IEnumerable<DepartmentDto>> GetByDirectorateId(Guid directorateId);
    Task<DepartmentDto> GetById(Guid id);
    Task<Guid> Create(DepartmentForCreationDto departmentDto);
    Task Update(Guid id, DepartmentForUpdateDto departmentDto);
    Task Delete(Guid id);
}
