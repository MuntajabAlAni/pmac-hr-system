using AutoMapper;
using Domain.Models;
using Application.DataTransferObjects;

namespace Application.Mapping;

public class CareerProfile : Profile
{
    public CareerProfile()
    {
        CreateMap<Grade, GradeDto>();
        CreateMap<GradeForCreationDto, Grade>();
        CreateMap<GradeForUpdateDto, Grade>();

        CreateMap<Step, StepDto>();
        CreateMap<StepForCreationDto, Step>();
        CreateMap<StepForUpdateDto, Step>();

        CreateMap<ServiceContinuation, ServiceContinuationDto>();
        CreateMap<ServiceContinuationForCreationDto, ServiceContinuation>();
        CreateMap<ServiceContinuationForUpdateDto, ServiceContinuation>();

        CreateMap<WorkCareerType, WorkCareerTypeDto>();
        CreateMap<WorkCareerTypeForCreationDto, WorkCareerType>();
        CreateMap<WorkCareerTypeForUpdateDto, WorkCareerType>();

        CreateMap<CommingFrom, CommingFromDto>();
        CreateMap<CommingFromForCreationDto, CommingFrom>();
        CreateMap<CommingFromForUpdateDto, CommingFrom>();

        CreateMap<FingerPrintExceptionType, FingerPrintExceptionTypeDto>();
        CreateMap<FingerPrintExceptionTypeForCreationDto, FingerPrintExceptionType>();
        CreateMap<FingerPrintExceptionTypeForUpdateDto, FingerPrintExceptionType>();

        CreateMap<Career, CareerDto>();
        CreateMap<CareerForCreationDto, Career>();
        CreateMap<CareerForUpdateDto, Career>();
    }
}
