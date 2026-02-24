using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class PositionService(IRepositoryManager repositoryManager, IMapper mapper) : IPositionService
{
    public async Task<IEnumerable<PositionDto>> GetAll()
    {
        var positions = await repositoryManager.Position.FindAll();
        return mapper.Map<IEnumerable<PositionDto>>(positions);
    }

    public async Task<PositionDto> GetById(Guid id)
    {
        var position = await repositoryManager.Position.FindById(id);
        if (position is null)
            throw new EntityNotFoundException("Position", "Id", id);

        return mapper.Map<PositionDto>(position);
    }

    public async Task<Guid> Create(PositionForCreationDto positionDto)
    {
        var position = mapper.Map<Position>(positionDto);
        return await repositoryManager.Position.Create(position);
    }

    public async Task Update(Guid id, PositionForUpdateDto positionDto)
    {
        var position = await repositoryManager.Position.FindById(id);
        if (position is null)
            throw new EntityNotFoundException("Position", "Id", id);

        mapper.Map(positionDto, position);
        position.Id = id;
        await repositoryManager.Position.Update(position);
    }

    public async Task Delete(Guid id)
    {
        var position = await repositoryManager.Position.FindById(id);
        if (position is null)
            throw new EntityNotFoundException("Position", "Id", id);

        await repositoryManager.Position.Delete(id);
    }
}
