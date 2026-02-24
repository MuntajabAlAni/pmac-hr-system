using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class VacationTotalService(IRepositoryManager repositoryManager, IMapper mapper) : IVacationTotalService
{
    public async Task<IEnumerable<VacationTotalDto>> GetAll()
    {
        var vacationTotals = await repositoryManager.VacationTotal.FindAll();
        return mapper.Map<IEnumerable<VacationTotalDto>>(vacationTotals);
    }

    public async Task<VacationTotalDto> GetById(Guid id)
    {
        var vacationTotal = await repositoryManager.VacationTotal.FindById(id);
        if (vacationTotal is null)
            throw new EntityNotFoundException("VacationTotal", "Id", id);

        return mapper.Map<VacationTotalDto>(vacationTotal);
    }

    public async Task<VacationTotalDto> GetByEmployeeId(Guid employeeId)
    {
        var vacationTotal = await repositoryManager.VacationTotal.FindByEmployeeId(employeeId);
        // It's possible an employee doesn't have a vacation total record yet, 
        // in which case we might want to return null or throw. 
        // For now, let's treat it as not found if required, or null if optional.
        if (vacationTotal is null)
             throw new EntityNotFoundException("VacationTotal", "EmployeeId", employeeId); // Or return empty DTO?

        return mapper.Map<VacationTotalDto>(vacationTotal);
    }

    public async Task<Guid> Create(VacationTotalForCreationDto vacationTotalDto)
    {
        var vacationTotal = mapper.Map<VacationTotal>(vacationTotalDto);
        return await repositoryManager.VacationTotal.Create(vacationTotal);
    }

    public async Task Update(Guid id, VacationTotalForUpdateDto vacationTotalDto)
    {
        var vacationTotal = await repositoryManager.VacationTotal.FindById(id);
        if (vacationTotal is null)
            throw new EntityNotFoundException("VacationTotal", "Id", id);

        mapper.Map(vacationTotalDto, vacationTotal);
        vacationTotal.Id = id;
        await repositoryManager.VacationTotal.Update(vacationTotal);
    }

    public async Task Delete(Guid id)
    {
        var vacationTotal = await repositoryManager.VacationTotal.FindById(id);
        if (vacationTotal is null)
            throw new EntityNotFoundException("VacationTotal", "Id", id);

        await repositoryManager.VacationTotal.Delete(id);
    }
}
