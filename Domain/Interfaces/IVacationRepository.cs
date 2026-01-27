using Domain.Models;
using Domain.RequestFeatures;

namespace Domain.Interfaces;

public interface IVacationRepository
{
    Task<(IEnumerable<Vacation>, int)> FindAll(PaginationParameters parameters);
    Task<IEnumerable<Vacation>> FindByEmployeeId(int employeeId);
    Task<Vacation?> FindById(int id);
    Task<int> Create(Vacation vacation);
    Task Update(Vacation vacation);
    Task Delete(int id);
}
