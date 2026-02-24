using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class UniversityService(IRepositoryManager repositoryManager, IMapper mapper) : IUniversityService
{
    public async Task<IEnumerable<UniversityDto>> GetAll()
    {
        var universities = await repositoryManager.University.FindAll();
        return mapper.Map<IEnumerable<UniversityDto>>(universities);
    }

    public async Task<UniversityDto> GetById(Guid id)
    {
        var university = await repositoryManager.University.FindById(id);
        if (university is null)
            throw new EntityNotFoundException("University", "Id", id);

        return mapper.Map<UniversityDto>(university);
    }

    public async Task<Guid> Create(UniversityForCreationDto universityDto)
    {
        var university = mapper.Map<University>(universityDto);
        return await repositoryManager.University.Create(university);
    }

    public async Task Update(Guid id, UniversityForUpdateDto universityDto)
    {
        var university = await repositoryManager.University.FindById(id);
        if (university is null)
            throw new EntityNotFoundException("University", "Id", id);

        mapper.Map(universityDto, university);
        university.Id = id;
        await repositoryManager.University.Update(university);
    }

    public async Task Delete(Guid id)
    {
        var university = await repositoryManager.University.FindById(id);
        if (university is null)
            throw new EntityNotFoundException("University", "Id", id);

        await repositoryManager.University.Delete(id);
    }
}
