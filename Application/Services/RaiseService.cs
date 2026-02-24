using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class RaiseService(IRepositoryManager repositoryManager, IMapper mapper) : IRaiseService
{
    public async Task<IEnumerable<RaiseDto>> GetAll()
    {
        var raises = await repositoryManager.Raise.FindAll();
        return mapper.Map<IEnumerable<RaiseDto>>(raises);
    }

    public async Task<RaiseDto> GetById(Guid id)
    {
        var raise = await repositoryManager.Raise.FindById(id);
        if (raise is null)
            throw new EntityNotFoundException("Raise", "Id", id);

        return mapper.Map<RaiseDto>(raise);
    }

    public async Task<IEnumerable<RaiseDto>> GetByEmployeeId(Guid employeeId)
    {
        var raises = await repositoryManager.Raise.FindByEmployeeId(employeeId);
        return mapper.Map<IEnumerable<RaiseDto>>(raises);
    }

    public async Task<Guid> Create(RaiseForCreationDto raiseDto)
    {
        var raise = mapper.Map<Raise>(raiseDto);
        return await repositoryManager.Raise.Create(raise);
    }

    public async Task Update(Guid id, RaiseForUpdateDto raiseDto)
    {
        var raise = await repositoryManager.Raise.FindById(id);
        if (raise is null)
            throw new EntityNotFoundException("Raise", "Id", id);

        mapper.Map(raiseDto, raise);
        raise.Id = id;
        await repositoryManager.Raise.Update(raise);
    }

    public async Task Delete(Guid id)
    {
        var raise = await repositoryManager.Raise.FindById(id);
        if (raise is null)
            throw new EntityNotFoundException("Raise", "Id", id);

        await repositoryManager.Raise.Delete(id);
    }
}
