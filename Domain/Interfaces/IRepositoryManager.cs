namespace Domain.Interfaces;

public interface IRepositoryManager
{
    IUserRepository User { get; }
    IEmployeeRepository Employee { get; }
    IDirectorateRepository Directorate { get; }
    IDepartmentRepository Department { get; }
    ISectionRepository Section { get; }
    IPositionRepository Position { get; }
    IJobTitleRepository JobTitle { get; }
    IRankRepository Rank { get; }
    IStoreEmployeeRepository StoreEmployee { get; }
    IGradeRepository Grade { get; }
    IStepRepository Step { get; }
    IServiceContinuationRepository ServiceContinuation { get; }
    IWorkCareerTypeRepository WorkCareerType { get; }
    ICommingFromRepository CommingFrom { get; }
    IFingerPrintExceptionTypeRepository FingerPrintExceptionType { get; }
    ICareerRepository Career { get; }
    IBasicSalaryRepository BasicSalary { get; }
    IRaiseTypeRepository RaiseType { get; }
    IRaiseRepository Raise { get; }
    IVacationRepository Vacation { get; }
    IVacationTypeRepository VacationType { get; }
    IVacationTotalRepository VacationTotal { get; }
    ITrainingCourseRepository TrainingCourse { get; }
    IUniversityRepository University { get; }
    IAdministrativeActionRepository AdministrativeAction { get; }
    IAdministrativeActionTypeRepository AdministrativeActionType { get; }
    IRewardRepository Reward { get; }
    ICommitteeRepository Committee { get; }
    IDeligationRepository Deligation { get; }
    IOfficialDocumentRepository OfficialDocument { get; }
    IOfficialDocumentTypeRepository OfficialDocumentType { get; }
    ICertificateRepository Certificate { get; }
    IEducationCertificateRepository EducationCertificate { get; }
    ICertificatePublisherRepository CertificatePublisher { get; }
    IPersonalCardRepository PersonalCard { get; }
    IMaritalStatusRepository MaritalStatus { get; }
    IServiceTypeRepository ServiceType { get; }
    ITaskStatusRepository TaskStatus { get; }
    ILogFileRepository LogFile { get; }
    IAddedServiceRepository AddedService { get; }
    IConsultantTaskRepository ConsultantTask { get; }
}