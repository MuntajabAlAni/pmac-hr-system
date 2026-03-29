using Domain.Entities.EmploymentStructure;

namespace Domain.Interfaces;

public interface IJobTitleRepository
{
    Task<IEnumerable<JobTitle>> FindAll();
    Task<JobTitle?> FindById(Guid id);
    Task<Guid> Create(JobTitle jobTitle);
    Task Update(JobTitle jobTitle);
    Task Delete(Guid id);
}
