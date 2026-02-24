using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface IFingerPrintExceptionTypeService
{
    Task<IEnumerable<FingerPrintExceptionTypeDto>> GetAll();
    Task<FingerPrintExceptionTypeDto> GetById(Guid id);
    Task<Guid> Create(FingerPrintExceptionTypeForCreationDto fingerPrintExceptionTypeDto);
    Task Update(Guid id, FingerPrintExceptionTypeForUpdateDto fingerPrintExceptionTypeDto);
    Task Delete(Guid id);
}
