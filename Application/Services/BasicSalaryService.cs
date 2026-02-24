using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class BasicSalaryService(IRepositoryManager repositoryManager, IMapper mapper) : IBasicSalaryService
{
    public async Task<IEnumerable<BasicSalaryDto>> GetAll()
    {
        var basicSalaries = await repositoryManager.BasicSalary.FindAll();
        return mapper.Map<IEnumerable<BasicSalaryDto>>(basicSalaries);
    }

    public async Task<BasicSalaryDto> GetById(Guid id)
    {
        var basicSalary = await repositoryManager.BasicSalary.FindById(id);
        if (basicSalary is null)
            throw new EntityNotFoundException("BasicSalary", "Id", id);

        return mapper.Map<BasicSalaryDto>(basicSalary);
    }

    public async Task<Guid> Create(BasicSalaryForCreationDto basicSalaryDto)
    {
        var basicSalary = mapper.Map<BasicSalary>(basicSalaryDto);
        return await repositoryManager.BasicSalary.Create(basicSalary);
    }

    public async Task Update(Guid id, BasicSalaryForUpdateDto basicSalaryDto)
    {
        var basicSalary = await repositoryManager.BasicSalary.FindById(id);
        if (basicSalary is null)
            throw new EntityNotFoundException("BasicSalary", "Id", id);

        mapper.Map(basicSalaryDto, basicSalary);
        basicSalary.Id = id;
        await repositoryManager.BasicSalary.Update(basicSalary);
    }

    public async Task Delete(Guid id)
    {
        var basicSalary = await repositoryManager.BasicSalary.FindById(id);
        if (basicSalary is null)
            throw new EntityNotFoundException("BasicSalary", "Id", id);

        await repositoryManager.BasicSalary.Delete(id);
    }
}
