using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
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

    public async Task<Guid> Create(DirectorateForCreationDto directorateDto)
    {
        var directorate = mapper.Map<Directorate>(directorateDto);
        return await repositoryManager.Directorate.Create(directorate);
    }

    public async Task Update(Guid id, DirectorateForUpdateDto directorateDto)
    {
        var directorate = await repositoryManager.Directorate.FindById(id);
        if (directorate is null)
            throw new EntityNotFoundException("Directorate", "Id", id);

        mapper.Map(directorateDto, directorate);
        directorate.Id = id;
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
