using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface IUniversityService
{
    Task<IEnumerable<UniversityDto>> GetAll();
    Task<UniversityDto> GetById(Guid id);
    Task<Guid> Create(UniversityForCreationDto universityDto);
    Task Update(Guid id, UniversityForUpdateDto universityDto);
    Task Delete(Guid id);
}
