using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class DeligationService(IRepositoryManager repositoryManager, IMapper mapper) : IDeligationService
{
    public async Task<IEnumerable<DeligationDto>> GetAll()
    {
        var deligations = await repositoryManager.Deligation.FindAll();
        return mapper.Map<IEnumerable<DeligationDto>>(deligations);
    }

    public async Task<DeligationDto> GetById(Guid id)
    {
        var deligation = await repositoryManager.Deligation.FindById(id);
        if (deligation is null)
            throw new EntityNotFoundException("Deligation", "Id", id);

        return mapper.Map<DeligationDto>(deligation);
    }

    public async Task<Guid> Create(DeligationForCreationDto deligationDto)
    {
        var deligation = mapper.Map<Deligation>(deligationDto);
        return await repositoryManager.Deligation.Create(deligation);
    }

    public async Task Update(Guid id, DeligationForUpdateDto deligationDto)
    {
        var deligation = await repositoryManager.Deligation.FindById(id);
        if (deligation is null)
            throw new EntityNotFoundException("Deligation", "Id", id);

        mapper.Map(deligationDto, deligation);
        deligation.Id = id;
        await repositoryManager.Deligation.Update(deligation);
    }

    public async Task Delete(Guid id)
    {
        var deligation = await repositoryManager.Deligation.FindById(id);
        if (deligation is null)
            throw new EntityNotFoundException("Deligation", "Id", id);

        await repositoryManager.Deligation.Delete(id);
    }
}
