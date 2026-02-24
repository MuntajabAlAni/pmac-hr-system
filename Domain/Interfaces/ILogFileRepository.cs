using Domain.Models;

namespace Domain.Interfaces;

public interface ILogFileRepository
{
    Task<IEnumerable<LogFile>> FindAll();
    Task<LogFile?> FindById(Guid id);
    Task<Guid> Create(LogFile logFile);
}
