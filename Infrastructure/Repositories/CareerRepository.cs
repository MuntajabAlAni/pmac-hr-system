using Dapper;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;

namespace Infrastructure.Repositories;

public class CareerRepository(DapperContext context) : ICareerRepository
{
    public async Task<IEnumerable<Career>> FindAll()
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<Career>(CareerQueries.FindAllQuery);
    }

    public async Task<Career?> FindById(Guid id)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Career>(CareerQueries.FindByIdQuery, new { Id = id });
    }

    public async Task<IEnumerable<Career>> FindByEmployeeId(Guid employeeId)
    {
        using var connection = context.CreateConnection();
        return await connection.QueryAsync<Career>(CareerQueries.FindByEmployeeIdQuery, new { EmployeeId = employeeId });
    }

    public async Task<Guid> Create(Career career)
    {
        if (career.Id == Guid.Empty)
            career.Id = Guid.CreateVersion7();

        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(CareerQueries.InsertQuery, new
        {
            Id = career.Id,
            career.EmployeeId,
            career.EmployeeNationalNumber,
            career.DirectorateId,
            career.DepartmentId,
            career.SectionId,
            career.JobTitleId,
            career.PositionId,
            career.RankId,
            GradeId = career.GradeId,
            StepId = career.StepId,
            career.ContinuationId,
            career.WorkCareerTypeId,
            career.SideId,
            career.ExceptionTypeId,
            career.EmploymentStatus,
            career.LastPromotionDate,
            career.LastRaiseDate,
            career.NextRaiseDate,
            career.BasicSalary,
            career.Education,
            career.CareerNotes,
            career.ServiceSummaryNotes,
            career.AssignBookNumber,
            career.AssignBookDate,
            career.InitiationBookNumber,
            career.InitiationBookDate,
            career.InitiationActualDate,
            career.InitiationAtOfficeBookNumber,
            career.InitiationAtOfficeBookDate,
            career.AdditionalService,
            career.MartyreRelated,
            career.PoliticalPrisoner,
            career.PoliticalIsolation,
            career.EndOfServiceDate,
            career.HasLeftEarlier,
            career.Transferred,
            career.DeletionBookNumber,
            career.UpdateBookNumber,
            career.PreviousDirectorate,
            career.NormalVacationCredit,
            career.IllnessVacationCredit,
            career.HasFingerprint,
            career.FingerprintDate,
            career.MinistryFinanceApproval,
            career.ApprovalType
        });
        return career.Id;
    }

    public async Task Update(Career career)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(CareerQueries.UpdateQuery, new
        {
            Id = career.Id,
            career.EmployeeId,
            career.EmployeeNationalNumber,
            career.DirectorateId,
            career.DepartmentId,
            career.SectionId,
            career.JobTitleId,
            career.PositionId,
            career.RankId,
            GradeId = career.GradeId,
            StepId = career.StepId,
            career.ContinuationId,
            career.WorkCareerTypeId,
            career.SideId,
            career.ExceptionTypeId,
            career.EmploymentStatus,
            career.LastPromotionDate,
            career.LastRaiseDate,
            career.NextRaiseDate,
            career.BasicSalary,
            career.Education,
            career.CareerNotes,
            career.ServiceSummaryNotes,
            career.AssignBookNumber,
            career.AssignBookDate,
            career.InitiationBookNumber,
            career.InitiationBookDate,
            career.InitiationActualDate,
            career.InitiationAtOfficeBookNumber,
            career.InitiationAtOfficeBookDate,
            career.AdditionalService,
            career.MartyreRelated,
            career.PoliticalPrisoner,
            career.PoliticalIsolation,
            career.EndOfServiceDate,
            career.HasLeftEarlier,
            career.Transferred,
            career.DeletionBookNumber,
            career.UpdateBookNumber,
            career.PreviousDirectorate,
            career.NormalVacationCredit,
            career.IllnessVacationCredit,
            career.HasFingerprint,
            career.FingerprintDate,
            career.MinistryFinanceApproval,
            career.ApprovalType
        });
    }

    public async Task Delete(Guid id)
    {
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(CareerQueries.DeleteQuery, new { Id = id });
    }
}
