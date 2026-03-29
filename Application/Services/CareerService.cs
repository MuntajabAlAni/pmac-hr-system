using AutoMapper;
using Domain.Exceptions;
using Domain.Entities.Career;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class CareerService(IRepositoryManager repositoryManager, IMapper mapper) : ICareerService
{
    public async Task<IEnumerable<CareerDto>> GetAll()
    {
        var careers = await repositoryManager.Career.FindAll();
        return mapper.Map<IEnumerable<CareerDto>>(careers);
    }

    public async Task<CareerDto> GetById(Guid id)
    {
        var career = await repositoryManager.Career.FindById(id);
        if (career is null)
            throw new EntityNotFoundException("Career", "Id", id);

        return mapper.Map<CareerDto>(career);
    }

    public async Task<IEnumerable<CareerDto>> GetByEmployeeId(Guid employeeId)
    {
        var careers = await repositoryManager.Career.FindByEmployeeId(employeeId);
        return mapper.Map<IEnumerable<CareerDto>>(careers);
    }

    public async Task<Guid> Create(CareerForCreationDto dto)
    {
        // Use domain constructor (DDD)
        var career = new Career(
            employeeId: dto.EmployeeId,
            movementDate: dto.MovementDate,
            movementType: dto.MovementType,
            authorityName: dto.AuthorityName,
            directorateName: dto.DirectorateName,
            departmentName: dto.DepartmentName,
            sectionName: dto.SectionName,
            jobTitle: dto.JobTitle,
            gradeName: dto.GradeName,
            basicSalary: dto.BasicSalary,
            userGuid: Guid.Empty,
            subAuthorityName: dto.SubAuthorityName,
            subDirectorateName: dto.SubDirectorateName,
            unitName: dto.UnitName,
            notes: dto.Notes
        );

        return await repositoryManager.Career.Create(career);
    }

    public async Task Update(Guid id, CareerForUpdateDto dto)
    {
        var career = await repositoryManager.Career.FindById(id);
        if (career is null)
            throw new EntityNotFoundException("Career", "Id", id);

        // Career only allows updating notes (DDD)
        career.UpdateNotes(dto.Notes, Guid.Empty);
        await repositoryManager.Career.Update(career);
    }

    public async Task Delete(Guid id)
    {
        var career = await repositoryManager.Career.FindById(id);
        if (career is null)
            throw new EntityNotFoundException("Career", "Id", id);

        await repositoryManager.Career.Delete(id);
    }
}
