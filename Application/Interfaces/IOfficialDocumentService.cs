using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface IOfficialDocumentService
{
    Task<IEnumerable<OfficialDocumentDto>> GetAll();
    Task<OfficialDocumentDto> GetById(Guid id);
    Task<Guid> Create(OfficialDocumentForCreationDto officialDocumentDto);
    Task Update(Guid id, OfficialDocumentForUpdateDto officialDocumentDto);
    Task Delete(Guid id);
}
