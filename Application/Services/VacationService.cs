using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class VacationService(IRepositoryManager repositoryManager, IMapper mapper) : IVacationService
{
    public async Task<IEnumerable<VacationDto>> GetAll()
    {
        var vacations = await repositoryManager.Vacation.FindAll();
        return mapper.Map<IEnumerable<VacationDto>>(vacations);
    }

    public async Task<VacationDto> GetById(Guid id)
    {
        var vacation = await repositoryManager.Vacation.FindById(id);
        if (vacation is null)
            throw new EntityNotFoundException("Vacation", "Id", id);

        return mapper.Map<VacationDto>(vacation);
    }

    public async Task<IEnumerable<VacationDto>> GetByEmployeeId(Guid employeeId)
    {
        var vacations = await repositoryManager.Vacation.FindByEmployeeId(employeeId);
        return mapper.Map<IEnumerable<VacationDto>>(vacations);
    }

    public async Task<Guid> Create(VacationForCreationDto vacationDto)
    {
        var vacation = mapper.Map<Vacation>(vacationDto);
        return await repositoryManager.Vacation.Create(vacation);
    }

    public async Task Update(Guid id, VacationForUpdateDto vacationDto)
    {
        var vacation = await repositoryManager.Vacation.FindById(id);
        if (vacation is null)
            throw new EntityNotFoundException("Vacation", "Id", id);

        mapper.Map(vacationDto, vacation);
        vacation.Id = id;
        await repositoryManager.Vacation.Update(vacation);
    }

    public async Task Delete(Guid id)
    {
        var vacation = await repositoryManager.Vacation.FindById(id);
        if (vacation is null)
            throw new EntityNotFoundException("Vacation", "Id", id);

        await repositoryManager.Vacation.Delete(id);
    }
}
