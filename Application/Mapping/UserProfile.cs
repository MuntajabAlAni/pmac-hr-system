using AutoMapper;
using Domain.Models;
using Application.DataTransferObjects;

namespace Application.Mapping;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<User, UserDetailsDto>();
        CreateMap<User, UserDetailsWithTokensDto>();
        CreateMap<UserForRegistrationDto, User>();
        CreateMap<UserForManipulationDto, User>();
        CreateMap<UserForAdminManipulationDto, User>();
        CreateMap<LoggedInUserForUpdateDto, User>();
        CreateMap<Role, RoleDto>();
        CreateMap<RoleForManipulationDto, Role>();
        CreateMap<UserLocation, UserLocationDto>();
        CreateMap<UserLocationForManipulationDto, UserLocation>();
    }
}