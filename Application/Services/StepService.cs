using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class StepService(IRepositoryManager repositoryManager, IMapper mapper) : IStepService
{
    public async Task<IEnumerable<StepDto>> GetAll()
    {
        var steps = await repositoryManager.Step.FindAll();
        return mapper.Map<IEnumerable<StepDto>>(steps);
    }

    public async Task<StepDto> GetById(Guid id)
    {
        var step = await repositoryManager.Step.FindById(id);
        if (step is null)
            throw new EntityNotFoundException("Step", "Id", id);

        return mapper.Map<StepDto>(step);
    }

    public async Task<Guid> Create(StepForCreationDto stepDto)
    {
        var step = mapper.Map<Step>(stepDto);
        return await repositoryManager.Step.Create(step);
    }

    public async Task Update(Guid id, StepForUpdateDto stepDto)
    {
        var step = await repositoryManager.Step.FindById(id);
        if (step is null)
            throw new EntityNotFoundException("Step", "Id", id);

        mapper.Map(stepDto, step);
        step.Id = id;
        await repositoryManager.Step.Update(step);
    }

    public async Task Delete(Guid id)
    {
        var step = await repositoryManager.Step.FindById(id);
        if (step is null)
            throw new EntityNotFoundException("Step", "Id", id);

        await repositoryManager.Step.Delete(id);
    }
}
