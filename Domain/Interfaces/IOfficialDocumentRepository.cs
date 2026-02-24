using Domain.Models;

namespace Domain.Interfaces;

public interface IOfficialDocumentRepository
{
    Task<IEnumerable<OfficialDocument>> FindAll();
    Task<OfficialDocument?> FindById(Guid id);
    Task<Guid> Create(OfficialDocument officialDocument);
    Task Update(OfficialDocument officialDocument);
    Task Delete(Guid id);
}
