using AutoMapper;
using Domain.Exceptions;
using Domain.Entities.Vacations;
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

    public async Task<Guid> Create(VacationTypeForCreationDto dto)
    {
        // Use domain constructor (DDD)
        var vacationType = new VacationType(
            name: dto.Name,
            isConditional: dto.IsConditional,
            isCountedInBalance: dto.IsCountedInBalance,
            bonusAffect: dto.BonusAffect,
            promotionAffect: dto.PromotionAffect,
            userGuid: Guid.Empty
        );

        return await repositoryManager.VacationType.Create(vacationType);
    }

    public async Task Update(Guid id, VacationTypeForUpdateDto dto)
    {
        var vacationType = await repositoryManager.VacationType.FindById(id);
        if (vacationType is null)
            throw new EntityNotFoundException("VacationType", "Id", id);

        // Use domain Update method
        vacationType.Update(
            dto.Name,
            dto.IsConditional,
            dto.IsCountedInBalance,
            dto.BonusAffect,
            dto.PromotionAffect,
            Guid.Empty
        );
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
