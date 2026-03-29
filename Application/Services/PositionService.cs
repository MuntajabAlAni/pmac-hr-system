using AutoMapper;
using Domain.Exceptions;
using Domain.Entities.EmploymentStructure;
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

    public async Task<Guid> Create(PositionForCreationDto dto)
    {
        // Use domain constructor (DDD)
        var position = new Position(
            positionName: dto.PositionName,
            positionLevel: dto.PositionLevel,
            userGuid: Guid.Empty
        );

        return await repositoryManager.Position.Create(position);
    }

    public async Task Update(Guid id, PositionForUpdateDto dto)
    {
        var position = await repositoryManager.Position.FindById(id);
        if (position is null)
            throw new EntityNotFoundException("Position", "Id", id);

        // Use domain Update method
        position.Update(dto.PositionName, dto.PositionLevel, Guid.Empty);
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
