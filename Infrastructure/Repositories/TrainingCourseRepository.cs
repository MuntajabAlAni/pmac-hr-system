using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class TrainingCourseRepository(DapperContext context) : ITrainingCourseRepository
{
    public async Task<IEnumerable<TrainingCourse>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<TrainingCourse>(TrainingCourseQueries.FindAllQuery);
    }

    public async Task<TrainingCourse?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<TrainingCourse>(TrainingCourseQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<IEnumerable<TrainingCourse>> FindByEmployeeId(Guid employeeId)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<TrainingCourse>(TrainingCourseQueries.FindByEmployeeIdQuery, new { EmployeeId = employeeId });
    }

    public async Task<Guid> Create(TrainingCourse trainingCourse)
    {
        if (trainingCourse.Id == Guid.Empty)
            trainingCourse.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(TrainingCourseQueries.InsertQuery, trainingCourse);
        return trainingCourse.Id;
    }

    public async Task Update(TrainingCourse trainingCourse)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(TrainingCourseQueries.UpdateQuery, trainingCourse);
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(TrainingCourseQueries.DeleteQuery, new { Id = id });
    }
}
