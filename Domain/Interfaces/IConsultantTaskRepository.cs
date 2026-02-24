using Domain.Models;

namespace Domain.Interfaces;

public interface IConsultantTaskRepository
{
    Task<IEnumerable<ConsultantTask>> FindAll();
    Task<ConsultantTask?> FindById(Guid id);
    Task<Guid> Create(ConsultantTask consultantTask);
    Task Update(ConsultantTask consultantTask);
    Task Delete(Guid id);
}
