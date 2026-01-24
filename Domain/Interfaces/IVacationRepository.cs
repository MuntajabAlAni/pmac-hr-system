using Domain.Models;
using Domain.RequestFeatures;

namespace Domain.Interfaces;

public interface IVacationRepository
{
    Task<(IEnumerable<Vacation_Tbl>, int)> FindAll(PaginationParameters parameters);
    Task<IEnumerable<Vacation_Tbl>> FindByEmployeeId(int employeeId);
    Task<Vacation_Tbl?> FindById(int id);
    Task<int> Create(Vacation_Tbl vacation);
    Task Update(Vacation_Tbl vacation);
    Task Delete(int id);
}
