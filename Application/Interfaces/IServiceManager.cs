namespace Application.Interfaces;

public interface IServiceManager
{
    IUserService UserService { get; }
    IEmployeeService EmployeeService { get; }
    IDirectorateService DirectorateService { get; }
    IDepartmentService DepartmentService { get; }
    ISectionService SectionService { get; }
    IPositionService PositionService { get; }
    IJobTitleService JobTitleService { get; }
    IRankService RankService { get; }
    IStoreEmployeeService StoreEmployeeService { get; }
    IGradeService GradeService { get; }
    IStepService StepService { get; }
    IServiceContinuationService ServiceContinuationService { get; }
    IWorkCareerTypeService WorkCareerTypeService { get; }
    ICommingFromService CommingFromService { get; }
    IFingerPrintExceptionTypeService FingerPrintExceptionTypeService { get; }
    ICareerService CareerService { get; }
    IBasicSalaryService BasicSalaryService { get; }
    IRaiseTypeService RaiseTypeService { get; }
    IRaiseService RaiseService { get; }
    IVacationService VacationService { get; }
    IVacationTypeService VacationTypeService { get; }
    IVacationTotalService VacationTotalService { get; }
    ITrainingCourseService TrainingCourseService { get; }
    IUniversityService UniversityService { get; }
    IAdministrativeActionService AdministrativeActionService { get; }
    IAdministrativeActionTypeService AdministrativeActionTypeService { get; }
    IRewardService RewardService { get; }
    ICommitteeService CommitteeService { get; }
    IDeligationService DeligationService { get; }
    IOfficialDocumentService OfficialDocumentService { get; }
    IOfficialDocumentTypeService OfficialDocumentTypeService { get; }
    ICertificateService CertificateService { get; }
    IEducationCertificateService EducationCertificateService { get; }
    ICertificatePublisherService CertificatePublisherService { get; }
    IPersonalCardService PersonalCardService { get; }
    IMaritalStatusService MaritalStatusService { get; }
    IServiceTypeService ServiceTypeService { get; }
    ITaskStatusService TaskStatusService { get; }
    ILogFileService LogFileService { get; }
    IAddedServiceService AddedServiceService { get; }
    IConsultantTaskService ConsultantTaskService { get; }
}