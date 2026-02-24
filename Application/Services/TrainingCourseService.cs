using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class TrainingCourseService(IRepositoryManager repositoryManager, IMapper mapper) : ITrainingCourseService
{
    public async Task<IEnumerable<TrainingCourseDto>> GetAll()
    {
        var trainingCourses = await repositoryManager.TrainingCourse.FindAll();
        return mapper.Map<IEnumerable<TrainingCourseDto>>(trainingCourses);
    }

    public async Task<TrainingCourseDto> GetById(Guid id)
    {
        var trainingCourse = await repositoryManager.TrainingCourse.FindById(id);
        if (trainingCourse is null)
            throw new EntityNotFoundException("TrainingCourse", "Id", id);

        return mapper.Map<TrainingCourseDto>(trainingCourse);
    }

    public async Task<IEnumerable<TrainingCourseDto>> GetByEmployeeId(Guid employeeId)
    {
        var trainingCourses = await repositoryManager.TrainingCourse.FindByEmployeeId(employeeId);
        return mapper.Map<IEnumerable<TrainingCourseDto>>(trainingCourses);
    }

    public async Task<Guid> Create(TrainingCourseForCreationDto trainingCourseDto)
    {
        var trainingCourse = mapper.Map<TrainingCourse>(trainingCourseDto);
        return await repositoryManager.TrainingCourse.Create(trainingCourse);
    }

    public async Task Update(Guid id, TrainingCourseForUpdateDto trainingCourseDto)
    {
        var trainingCourse = await repositoryManager.TrainingCourse.FindById(id);
        if (trainingCourse is null)
            throw new EntityNotFoundException("TrainingCourse", "Id", id);

        mapper.Map(trainingCourseDto, trainingCourse);
        trainingCourse.Id = id;
        await repositoryManager.TrainingCourse.Update(trainingCourse);
    }

    public async Task Delete(Guid id)
    {
        var trainingCourse = await repositoryManager.TrainingCourse.FindById(id);
        if (trainingCourse is null)
            throw new EntityNotFoundException("TrainingCourse", "Id", id);

        await repositoryManager.TrainingCourse.Delete(id);
    }
}
