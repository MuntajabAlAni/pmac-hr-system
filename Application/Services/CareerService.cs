using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
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

    public async Task<Guid> Create(CareerForCreationDto careerDto)
    {
        var career = mapper.Map<Career>(careerDto);
        return await repositoryManager.Career.Create(career);
    }

    public async Task Update(Guid id, CareerForUpdateDto careerDto)
    {
        var career = await repositoryManager.Career.FindById(id);
        if (career is null)
            throw new EntityNotFoundException("Career", "Id", id);

        mapper.Map(careerDto, career);
        career.Id = id; // Ensure ID is preserved
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
