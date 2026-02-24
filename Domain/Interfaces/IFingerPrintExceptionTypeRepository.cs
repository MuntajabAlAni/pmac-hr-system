using Domain.Models;

namespace Domain.Interfaces;

public interface IFingerPrintExceptionTypeRepository
{
    Task<IEnumerable<FingerPrintExceptionType>> FindAll();
    Task<FingerPrintExceptionType?> FindById(Guid id);
    Task<Guid> Create(FingerPrintExceptionType fingerPrintExceptionType);
    Task Update(FingerPrintExceptionType fingerPrintExceptionType);
    Task Delete(Guid id);
}
