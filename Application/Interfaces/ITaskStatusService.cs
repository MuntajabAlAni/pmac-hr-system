using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface ITaskStatusService
{
    Task<IEnumerable<TaskStatusDto>> GetAll();
    Task<TaskStatusDto> GetById(Guid id);
    Task<Guid> Create(TaskStatusForCreationDto taskStatusDto);
    Task Update(Guid id, TaskStatusForUpdateDto taskStatusDto);
    Task Delete(Guid id);
}
