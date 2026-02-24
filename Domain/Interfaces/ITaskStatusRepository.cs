using Domain.Models;

namespace Domain.Interfaces;

public interface ITaskStatusRepository // Renamed here but it conflicts with System.Threading.Tasks.TaskStatus? Wait, Domain.Models.TaskStatus
{
    Task<IEnumerable<Domain.Models.TaskStatus>> FindAll();
    Task<Domain.Models.TaskStatus?> FindById(Guid id);
    Task<Guid> Create(Domain.Models.TaskStatus taskStatus);
    Task Update(Domain.Models.TaskStatus taskStatus);
    Task Delete(Guid id);
}
