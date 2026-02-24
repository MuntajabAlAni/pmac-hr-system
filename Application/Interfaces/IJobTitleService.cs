using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface IJobTitleService
{
    Task<IEnumerable<JobTitleDto>> GetAll();
    Task<JobTitleDto> GetById(Guid id);
    Task<Guid> Create(JobTitleForCreationDto jobTitleDto);
    Task Update(Guid id, JobTitleForUpdateDto jobTitleDto);
    Task Delete(Guid id);
}
