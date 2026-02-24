using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class OfficialDocumentService(IRepositoryManager repositoryManager, IMapper mapper) : IOfficialDocumentService
{
    public async Task<IEnumerable<OfficialDocumentDto>> GetAll()
    {
        var documents = await repositoryManager.OfficialDocument.FindAll();
        return mapper.Map<IEnumerable<OfficialDocumentDto>>(documents);
    }

    public async Task<OfficialDocumentDto> GetById(Guid id)
    {
        var document = await repositoryManager.OfficialDocument.FindById(id);
        if (document is null)
            throw new EntityNotFoundException("OfficialDocument", "Id", id);

        return mapper.Map<OfficialDocumentDto>(document);
    }

    public async Task<Guid> Create(OfficialDocumentForCreationDto officialDocumentDto)
    {
        var document = mapper.Map<OfficialDocument>(officialDocumentDto);
        return await repositoryManager.OfficialDocument.Create(document);
    }

    public async Task Update(Guid id, OfficialDocumentForUpdateDto officialDocumentDto)
    {
        var document = await repositoryManager.OfficialDocument.FindById(id);
        if (document is null)
            throw new EntityNotFoundException("OfficialDocument", "Id", id);

        mapper.Map(officialDocumentDto, document);
        document.Id = id;
        await repositoryManager.OfficialDocument.Update(document);
    }

    public async Task Delete(Guid id)
    {
        var document = await repositoryManager.OfficialDocument.FindById(id);
        if (document is null)
            throw new EntityNotFoundException("OfficialDocument", "Id", id);

        await repositoryManager.OfficialDocument.Delete(id);
    }
}
