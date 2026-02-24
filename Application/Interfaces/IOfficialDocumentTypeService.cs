using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface IOfficialDocumentTypeService
{
    Task<IEnumerable<OfficialDocumentTypeDto>> GetAll();
    Task<OfficialDocumentTypeDto> GetById(Guid id);
    Task<Guid> Create(OfficialDocumentTypeForCreationDto officialDocumentTypeDto);
    Task Update(Guid id, OfficialDocumentTypeForUpdateDto officialDocumentTypeDto);
    Task Delete(Guid id);
}
