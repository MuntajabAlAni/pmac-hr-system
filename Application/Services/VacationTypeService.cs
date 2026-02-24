using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class VacationTypeService(IRepositoryManager repositoryManager, IMapper mapper) : IVacationTypeService
{
    public async Task<IEnumerable<VacationTypeDto>> GetAll()
    {
        var vacationTypes = await repositoryManager.VacationType.FindAll();
        return mapper.Map<IEnumerable<VacationTypeDto>>(vacationTypes);
    }

    public async Task<VacationTypeDto> GetById(Guid id)
    {
        var vacationType = await repositoryManager.VacationType.FindById(id);
        if (vacationType is null)
            throw new EntityNotFoundException("VacationType", "Id", id);

        return mapper.Map<VacationTypeDto>(vacationType);
    }

    public async Task<Guid> Create(VacationTypeForCreationDto vacationTypeDto)
    {
        var vacationType = mapper.Map<VacationType>(vacationTypeDto);
        return await repositoryManager.VacationType.Create(vacationType);
    }

    public async Task Update(Guid id, VacationTypeForUpdateDto vacationTypeDto)
    {
        var vacationType = await repositoryManager.VacationType.FindById(id);
        if (vacationType is null)
            throw new EntityNotFoundException("VacationType", "Id", id);

        mapper.Map(vacationTypeDto, vacationType);
        vacationType.Id = id;
        await repositoryManager.VacationType.Update(vacationType);
    }

    public async Task Delete(Guid id)
    {
        var vacationType = await repositoryManager.VacationType.FindById(id);
        if (vacationType is null)
            throw new EntityNotFoundException("VacationType", "Id", id);

        await repositoryManager.VacationType.Delete(id);
    }
}
