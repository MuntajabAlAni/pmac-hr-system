using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface ISectionService
{
    Task<IEnumerable<SectionDto>> GetAll();
    Task<IEnumerable<SectionDto>> GetByDepartmentId(Guid departmentId);
    Task<SectionDto> GetById(Guid id);
    Task<Guid> Create(SectionForCreationDto sectionDto);
    Task Update(Guid id, SectionForUpdateDto sectionDto);
    Task Delete(Guid id);
}
