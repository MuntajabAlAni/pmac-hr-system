using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class OfficialDocumentTypeService(IRepositoryManager repositoryManager, IMapper mapper) : IOfficialDocumentTypeService
{
    public async Task<IEnumerable<OfficialDocumentTypeDto>> GetAll()
    {
        var types = await repositoryManager.OfficialDocumentType.FindAll();
        return mapper.Map<IEnumerable<OfficialDocumentTypeDto>>(types);
    }

    public async Task<OfficialDocumentTypeDto> GetById(Guid id)
    {
        var type = await repositoryManager.OfficialDocumentType.FindById(id);
        if (type is null)
            throw new EntityNotFoundException("OfficialDocumentType", "Id", id);

        return mapper.Map<OfficialDocumentTypeDto>(type);
    }

    public async Task<Guid> Create(OfficialDocumentTypeForCreationDto officialDocumentTypeDto)
    {
        var type = mapper.Map<OfficialDocumentType>(officialDocumentTypeDto);
        return await repositoryManager.OfficialDocumentType.Create(type);
    }

    public async Task Update(Guid id, OfficialDocumentTypeForUpdateDto officialDocumentTypeDto)
    {
        var type = await repositoryManager.OfficialDocumentType.FindById(id);
        if (type is null)
            throw new EntityNotFoundException("OfficialDocumentType", "Id", id);

        mapper.Map(officialDocumentTypeDto, type);
        type.Id = id;
        await repositoryManager.OfficialDocumentType.Update(type);
    }

    public async Task Delete(Guid id)
    {
        var type = await repositoryManager.OfficialDocumentType.FindById(id);
        if (type is null)
            throw new EntityNotFoundException("OfficialDocumentType", "Id", id);

        await repositoryManager.OfficialDocumentType.Delete(id);
    }
}
