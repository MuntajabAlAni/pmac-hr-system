using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface IDirectorateService
{
    Task<IEnumerable<DirectorateDto>> GetAll();
    Task<DirectorateDto> GetById(Guid id);
    Task<Guid> Create(DirectorateForCreationDto directorateDto);
    Task Update(Guid id, DirectorateForUpdateDto directorateDto);
    Task Delete(Guid id);
}
