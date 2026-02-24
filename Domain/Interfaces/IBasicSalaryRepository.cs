using Domain.Models;

namespace Domain.Interfaces;

public interface IBasicSalaryRepository
{
    Task<IEnumerable<BasicSalary>> FindAll();
    Task<BasicSalary?> FindById(Guid id);
    Task<Guid> Create(BasicSalary basicSalary);
    Task Update(BasicSalary basicSalary);
    Task Delete(Guid id);
}
