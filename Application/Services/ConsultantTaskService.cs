using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class ConsultantTaskService(IRepositoryManager repositoryManager, IMapper mapper) : IConsultantTaskService
{
    public async Task<IEnumerable<ConsultantTaskDto>> GetAll()
    {
        var consultantTasks = await repositoryManager.ConsultantTask.FindAll();
        return mapper.Map<IEnumerable<ConsultantTaskDto>>(consultantTasks);
    }

    public async Task<ConsultantTaskDto> GetById(Guid id)
    {
        var consultantTask = await repositoryManager.ConsultantTask.FindById(id);
        if (consultantTask is null)
            throw new EntityNotFoundException("ConsultantTask", "Id", id);

        return mapper.Map<ConsultantTaskDto>(consultantTask);
    }

    public async Task<Guid> Create(ConsultantTaskForCreationDto consultantTaskDto)
    {
        var consultantTask = mapper.Map<ConsultantTask>(consultantTaskDto);
        return await repositoryManager.ConsultantTask.Create(consultantTask);
    }

    public async Task Update(Guid id, ConsultantTaskForUpdateDto consultantTaskDto)
    {
        var consultantTask = await repositoryManager.ConsultantTask.FindById(id);
        if (consultantTask is null)
            throw new EntityNotFoundException("ConsultantTask", "Id", id);

        mapper.Map(consultantTaskDto, consultantTask);
        consultantTask.Id = id;
        await repositoryManager.ConsultantTask.Update(consultantTask);
    }

    public async Task Delete(Guid id)
    {
        var consultantTask = await repositoryManager.ConsultantTask.FindById(id);
        if (consultantTask is null)
            throw new EntityNotFoundException("ConsultantTask", "Id", id);

        await repositoryManager.ConsultantTask.Delete(id);
    }
}
