using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface ITrainingCourseService
{
    Task<IEnumerable<TrainingCourseDto>> GetAll();
    Task<TrainingCourseDto> GetById(Guid id);
    Task<IEnumerable<TrainingCourseDto>> GetByEmployeeId(Guid employeeId);
    Task<Guid> Create(TrainingCourseForCreationDto trainingCourseDto);
    Task Update(Guid id, TrainingCourseForUpdateDto trainingCourseDto);
    Task Delete(Guid id);
}
