using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface IBasicSalaryService
{
    Task<IEnumerable<BasicSalaryDto>> GetAll();
    Task<BasicSalaryDto> GetById(Guid id);
    Task<Guid> Create(BasicSalaryForCreationDto basicSalaryDto);
    Task Update(Guid id, BasicSalaryForUpdateDto basicSalaryDto);
    Task Delete(Guid id);
}
