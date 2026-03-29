using AutoMapper;
using Domain.Exceptions;
using Domain.Entities.Organizations;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class DirectorateService(IRepositoryManager repositoryManager, IMapper mapper) : IDirectorateService
{
    public async Task<IEnumerable<DirectorateDto>> GetAll()
    {
        var directorates = await repositoryManager.Directorate.FindAll();
        return mapper.Map<IEnumerable<DirectorateDto>>(directorates);
    }

    public async Task<DirectorateDto> GetById(Guid id)
    {
        var directorate = await repositoryManager.Directorate.FindById(id);
        if (directorate is null)
            throw new EntityNotFoundException("Directorate", "Id", id);

        return mapper.Map<DirectorateDto>(directorate);
    }

    public async Task<Guid> Create(DirectorateForCreationDto dto)
    {
        // Use domain constructor (DDD)
        var directorate = new Directorate(
            name: dto.Name,
            highAuthorityId: dto.HighAuthorityId,
            subHighAuthorityId: dto.SubHighAuthorityId,
            userGuid: Guid.Empty
        );

        return await repositoryManager.Directorate.Create(directorate);
    }

    public async Task Update(Guid id, DirectorateForUpdateDto dto)
    {
        var directorate = await repositoryManager.Directorate.FindById(id);
        if (directorate is null)
            throw new EntityNotFoundException("Directorate", "Id", id);

        // Use domain Update method
        directorate.Update(dto.Name, Guid.Empty);
        await repositoryManager.Directorate.Update(directorate);
    }

    public async Task Delete(Guid id)
    {
        var directorate = await repositoryManager.Directorate.FindById(id);
        if (directorate is null)
            throw new EntityNotFoundException("Directorate", "Id", id);

        await repositoryManager.Directorate.Delete(id);
    }
}
