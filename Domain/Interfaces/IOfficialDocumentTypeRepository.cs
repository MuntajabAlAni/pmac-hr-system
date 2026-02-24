using Domain.Models;

namespace Domain.Interfaces;

public interface IOfficialDocumentTypeRepository
{
    Task<IEnumerable<OfficialDocumentType>> FindAll();
    Task<OfficialDocumentType?> FindById(Guid id);
    Task<Guid> Create(OfficialDocumentType officialDocumentType);
    Task Update(OfficialDocumentType officialDocumentType);
    Task Delete(Guid id);
}
