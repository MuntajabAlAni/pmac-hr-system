using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface IConsultantTaskService
{
    Task<IEnumerable<ConsultantTaskDto>> GetAll();
    Task<ConsultantTaskDto> GetById(Guid id);
    Task<Guid> Create(ConsultantTaskForCreationDto consultantTaskDto);
    Task Update(Guid id, ConsultantTaskForUpdateDto consultantTaskDto);
    Task Delete(Guid id);
}
