using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface IGradeService
{
    Task<IEnumerable<GradeDto>> GetAll();
    Task<GradeDto> GetById(Guid id);
    Task<Guid> Create(GradeForCreationDto gradeDto);
    Task Update(Guid id, GradeForUpdateDto gradeDto);
    Task Delete(Guid id);
}
