using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface ICareerService
{
    Task<IEnumerable<CareerDto>> GetAll();
    Task<CareerDto> GetById(Guid id);
    Task<IEnumerable<CareerDto>> GetByEmployeeId(Guid employeeId);
    Task<Guid> Create(CareerForCreationDto careerDto);
    Task Update(Guid id, CareerForUpdateDto careerDto);
    Task Delete(Guid id);
}
