using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class ServiceContinuationService(IRepositoryManager repositoryManager, IMapper mapper) : IServiceContinuationService
{
    public async Task<IEnumerable<ServiceContinuationDto>> GetAll()
    {
        var serviceContinuations = await repositoryManager.ServiceContinuation.FindAll();
        return mapper.Map<IEnumerable<ServiceContinuationDto>>(serviceContinuations);
    }

    public async Task<ServiceContinuationDto> GetById(Guid id)
    {
        var serviceContinuation = await repositoryManager.ServiceContinuation.FindById(id);
        if (serviceContinuation is null)
            throw new EntityNotFoundException("ServiceContinuation", "Id", id);

        return mapper.Map<ServiceContinuationDto>(serviceContinuation);
    }

    public async Task<Guid> Create(ServiceContinuationForCreationDto serviceContinuationDto)
    {
        var serviceContinuation = mapper.Map<ServiceContinuation>(serviceContinuationDto);
        return await repositoryManager.ServiceContinuation.Create(serviceContinuation);
    }

    public async Task Update(Guid id, ServiceContinuationForUpdateDto serviceContinuationDto)
    {
        var serviceContinuation = await repositoryManager.ServiceContinuation.FindById(id);
        if (serviceContinuation is null)
            throw new EntityNotFoundException("ServiceContinuation", "Id", id);

        mapper.Map(serviceContinuationDto, serviceContinuation);
        serviceContinuation.Id = id;
        await repositoryManager.ServiceContinuation.Update(serviceContinuation);
    }

    public async Task Delete(Guid id)
    {
        var serviceContinuation = await repositoryManager.ServiceContinuation.FindById(id);
        if (serviceContinuation is null)
            throw new EntityNotFoundException("ServiceContinuation", "Id", id);

        await repositoryManager.ServiceContinuation.Delete(id);
    }
}
