using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
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

    public async Task<Guid> Create(SectionForCreationDto sectionDto)
    {
        var section = mapper.Map<Section>(sectionDto);
        return await repositoryManager.Section.Create(section);
    }

    public async Task Update(Guid id, SectionForUpdateDto sectionDto)
    {
        var section = await repositoryManager.Section.FindById(id);
        if (section is null)
            throw new EntityNotFoundException("Section", "Id", id);

        mapper.Map(sectionDto, section);
        section.Id = id;
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
