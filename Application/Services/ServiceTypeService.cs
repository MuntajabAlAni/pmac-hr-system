using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class ServiceTypeService(IRepositoryManager repositoryManager, IMapper mapper) : IServiceTypeService
{
    public async Task<IEnumerable<ServiceTypeDto>> GetAll()
    {
        var serviceTypes = await repositoryManager.ServiceType.FindAll();
        return mapper.Map<IEnumerable<ServiceTypeDto>>(serviceTypes);
    }

    public async Task<ServiceTypeDto> GetById(Guid id)
    {
        var serviceType = await repositoryManager.ServiceType.FindById(id);
        if (serviceType is null)
            throw new EntityNotFoundException("ServiceType", "Id", id);

        return mapper.Map<ServiceTypeDto>(serviceType);
    }

    public async Task<Guid> Create(ServiceTypeForCreationDto serviceTypeDto)
    {
        var serviceType = mapper.Map<ServiceType>(serviceTypeDto);
        return await repositoryManager.ServiceType.Create(serviceType);
    }

    public async Task Update(Guid id, ServiceTypeForUpdateDto serviceTypeDto)
    {
        var serviceType = await repositoryManager.ServiceType.FindById(id);
        if (serviceType is null)
            throw new EntityNotFoundException("ServiceType", "Id", id);

        mapper.Map(serviceTypeDto, serviceType);
        serviceType.Id = id;
        await repositoryManager.ServiceType.Update(serviceType);
    }

    public async Task Delete(Guid id)
    {
        var serviceType = await repositoryManager.ServiceType.FindById(id);
        if (serviceType is null)
            throw new EntityNotFoundException("ServiceType", "Id", id);

        await repositoryManager.ServiceType.Delete(id);
    }
}
