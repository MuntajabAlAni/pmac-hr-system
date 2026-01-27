using Domain.Models;

namespace Domain.Interfaces;

public interface ICareerRepository
{
    Task<Career?> FindByEmployeeId(int employeeId);
    Task<Career?> FindById(int id);
    Task<int> Create(Career career);
    Task Update(Career career);
    Task Delete(int id);
}
