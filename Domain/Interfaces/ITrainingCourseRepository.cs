using Domain.Models;

namespace Domain.Interfaces;

public interface ITrainingCourseRepository
{
    Task<IEnumerable<TrainingCourse>> FindAll();
    Task<TrainingCourse?> FindById(Guid id);
    Task<IEnumerable<TrainingCourse>> FindByEmployeeId(Guid employeeId);
    Task<Guid> Create(TrainingCourse trainingCourse);
    Task Update(TrainingCourse trainingCourse);
    Task Delete(Guid id);
}
