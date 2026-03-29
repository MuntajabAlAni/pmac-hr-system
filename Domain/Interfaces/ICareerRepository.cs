using Domain.Entities.Career;

namespace Domain.Interfaces;

public interface ICareerRepository
{
    Task<IEnumerable<Career>> FindAll();
    Task<Career?> FindById(Guid id);
    Task<IEnumerable<Career>> FindByEmployeeId(Guid employeeId);
    Task<Guid> Create(Career career);
    Task Update(Career career);
    Task Delete(Guid id);
}
