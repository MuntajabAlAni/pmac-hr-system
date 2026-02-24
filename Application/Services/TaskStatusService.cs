using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class TaskStatusService(IRepositoryManager repositoryManager, IMapper mapper) : ITaskStatusService
{
    public async Task<IEnumerable<TaskStatusDto>> GetAll()
    {
        var taskStatuses = await repositoryManager.TaskStatus.FindAll();
        return mapper.Map<IEnumerable<TaskStatusDto>>(taskStatuses);
    }

    public async Task<TaskStatusDto> GetById(Guid id)
    {
        var taskStatus = await repositoryManager.TaskStatus.FindById(id);
        if (taskStatus is null)
            throw new EntityNotFoundException("TaskStatus", "Id", id);

        return mapper.Map<TaskStatusDto>(taskStatus);
    }

    public async Task<Guid> Create(TaskStatusForCreationDto taskStatusDto)
    {
        var taskStatus = mapper.Map<Domain.Models.TaskStatus>(taskStatusDto);
        return await repositoryManager.TaskStatus.Create(taskStatus);
    }

    public async Task Update(Guid id, TaskStatusForUpdateDto taskStatusDto)
    {
        var taskStatus = await repositoryManager.TaskStatus.FindById(id);
        if (taskStatus is null)
            throw new EntityNotFoundException("TaskStatus", "Id", id);

        mapper.Map(taskStatusDto, taskStatus);
        taskStatus.Id = id;
        await repositoryManager.TaskStatus.Update(taskStatus);
    }

    public async Task Delete(Guid id)
    {
        var taskStatus = await repositoryManager.TaskStatus.FindById(id);
        if (taskStatus is null)
            throw new EntityNotFoundException("TaskStatus", "Id", id);

        await repositoryManager.TaskStatus.Delete(id);
    }
}
