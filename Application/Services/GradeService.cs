using AutoMapper;
using Domain.Exceptions;
using Domain.Entities.EmploymentStructure;
using Domain.Interfaces;
using Application.Interfaces;
using Application.DataTransferObjects;

namespace Application.Services;

public class GradeService(IRepositoryManager repositoryManager, IMapper mapper) : IGradeService
{
    public async Task<IEnumerable<GradeDto>> GetAll()
    {
        var grades = await repositoryManager.Grade.FindAll();
        return mapper.Map<IEnumerable<GradeDto>>(grades);
    }

    public async Task<GradeDto> GetById(Guid id)
    {
        var grade = await repositoryManager.Grade.FindById(id);
        if (grade is null)
            throw new EntityNotFoundException("Grade", "Id", id);

        return mapper.Map<GradeDto>(grade);
    }

    public async Task<Guid> Create(GradeForCreationDto dto)
    {
        // Use domain constructor (DDD)
        var grade = new Grade(
            gradeName: dto.GradeName,
            gradeLevel: dto.GradeLevel,
            userGuid: Guid.Empty
        );

        return await repositoryManager.Grade.Create(grade);
    }

    public async Task Update(Guid id, GradeForUpdateDto dto)
    {
        var grade = await repositoryManager.Grade.FindById(id);
        if (grade is null)
            throw new EntityNotFoundException("Grade", "Id", id);

        // Use domain Update method
        grade.Update(dto.GradeName, dto.GradeLevel, Guid.Empty);
        await repositoryManager.Grade.Update(grade);
    }

    public async Task Delete(Guid id)
    {
        var grade = await repositoryManager.Grade.FindById(id);
        if (grade is null)
            throw new EntityNotFoundException("Grade", "Id", id);

        await repositoryManager.Grade.Delete(id);
    }
}
