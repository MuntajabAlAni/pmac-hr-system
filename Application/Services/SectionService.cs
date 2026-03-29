using AutoMapper;
using Domain.Exceptions;
using Domain.Entities.Organizations;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class SectionService(IRepositoryManager repositoryManager, IMapper mapper) : ISectionService
{
    public async Task<IEnumerable<SectionDto>> GetAll()
    {
        var sections = await repositoryManager.Section.FindAll();
        return mapper.Map<IEnumerable<SectionDto>>(sections);
    }

    public async Task<IEnumerable<SectionDto>> GetByDepartmentId(Guid departmentId)
    {
        var sections = await repositoryManager.Section.FindByDepartmentId(departmentId);
        return mapper.Map<IEnumerable<SectionDto>>(sections);
    }

    public async Task<SectionDto> GetById(Guid id)
    {
        var section = await repositoryManager.Section.FindById(id);
        if (section is null)
            throw new EntityNotFoundException("Section", "Id", id);

        return mapper.Map<SectionDto>(section);
    }

    public async Task<Guid> Create(SectionForCreationDto dto)
    {
        // Use domain constructor (DDD)
        var section = new Section(
            name: dto.Name,
            highAuthorityId: dto.HighAuthorityId,
            subHighAuthorityId: dto.SubHighAuthorityId,
            directorateId: dto.DirectorateId,
            subDirectorateId: dto.SubDirectorateId,
            departmentId: dto.DepartmentId,
            userGuid: Guid.Empty
        );

        return await repositoryManager.Section.Create(section);
    }

    public async Task Update(Guid id, SectionForUpdateDto dto)
    {
        var section = await repositoryManager.Section.FindById(id);
        if (section is null)
            throw new EntityNotFoundException("Section", "Id", id);

        // Use domain Update method
        section.Update(dto.Name, Guid.Empty);
        await repositoryManager.Section.Update(section);
    }

    public async Task Delete(Guid id)
    {
        var section = await repositoryManager.Section.FindById(id);
        if (section is null)
            throw new EntityNotFoundException("Section", "Id", id);

        await repositoryManager.Section.Delete(id);
    }
}
