using AutoMapper;
using Domain.Exceptions;
using Domain.Entities.EmploymentStructure;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class JobTitleService(IRepositoryManager repositoryManager, IMapper mapper) : IJobTitleService
{
    public async Task<IEnumerable<JobTitleDto>> GetAll()
    {
        var jobTitles = await repositoryManager.JobTitle.FindAll();
        return mapper.Map<IEnumerable<JobTitleDto>>(jobTitles);
    }

    public async Task<JobTitleDto> GetById(Guid id)
    {
        var jobTitle = await repositoryManager.JobTitle.FindById(id);
        if (jobTitle is null)
            throw new EntityNotFoundException("JobTitle", "Id", id);

        return mapper.Map<JobTitleDto>(jobTitle);
    }

    public async Task<Guid> Create(JobTitleForCreationDto dto)
    {
        // Use domain constructor (DDD)
        var jobTitle = new JobTitle(
            title: dto.Title,
            gradeId: dto.GradeId,
            jobTitleType: dto.JobTitleType,
            userGuid: Guid.Empty
        );

        return await repositoryManager.JobTitle.Create(jobTitle);
    }

    public async Task Update(Guid id, JobTitleForUpdateDto dto)
    {
        var jobTitle = await repositoryManager.JobTitle.FindById(id);
        if (jobTitle is null)
            throw new EntityNotFoundException("JobTitle", "Id", id);

        // Use domain Update method
        jobTitle.Update(dto.Title, dto.GradeId, dto.JobTitleType, Guid.Empty);
        await repositoryManager.JobTitle.Update(jobTitle);
    }

    public async Task Delete(Guid id)
    {
        var jobTitle = await repositoryManager.JobTitle.FindById(id);
        if (jobTitle is null)
            throw new EntityNotFoundException("JobTitle", "Id", id);

        await repositoryManager.JobTitle.Delete(id);
    }
}
