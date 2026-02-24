using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class FingerPrintExceptionTypeService(IRepositoryManager repositoryManager, IMapper mapper) : IFingerPrintExceptionTypeService
{
    public async Task<IEnumerable<FingerPrintExceptionTypeDto>> GetAll()
    {
        var exceptionTypes = await repositoryManager.FingerPrintExceptionType.FindAll();
        return mapper.Map<IEnumerable<FingerPrintExceptionTypeDto>>(exceptionTypes);
    }

    public async Task<FingerPrintExceptionTypeDto> GetById(Guid id)
    {
        var exceptionType = await repositoryManager.FingerPrintExceptionType.FindById(id);
        if (exceptionType is null)
            throw new EntityNotFoundException("FingerPrintExceptionType", "Id", id);

        return mapper.Map<FingerPrintExceptionTypeDto>(exceptionType);
    }

    public async Task<Guid> Create(FingerPrintExceptionTypeForCreationDto exceptionTypeDto)
    {
        var exceptionType = mapper.Map<FingerPrintExceptionType>(exceptionTypeDto);
        return await repositoryManager.FingerPrintExceptionType.Create(exceptionType);
    }

    public async Task Update(Guid id, FingerPrintExceptionTypeForUpdateDto exceptionTypeDto)
    {
        var exceptionType = await repositoryManager.FingerPrintExceptionType.FindById(id);
        if (exceptionType is null)
            throw new EntityNotFoundException("FingerPrintExceptionType", "Id", id);

        mapper.Map(exceptionTypeDto, exceptionType);
        exceptionType.Id = id;
        await repositoryManager.FingerPrintExceptionType.Update(exceptionType);
    }

    public async Task Delete(Guid id)
    {
        var exceptionType = await repositoryManager.FingerPrintExceptionType.FindById(id);
        if (exceptionType is null)
            throw new EntityNotFoundException("FingerPrintExceptionType", "Id", id);

        await repositoryManager.FingerPrintExceptionType.Delete(id);
    }
}
