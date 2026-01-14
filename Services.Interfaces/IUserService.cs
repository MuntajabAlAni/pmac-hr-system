using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Services.Interfaces;

public interface IUserService
{
    Task<Guid> Register(UserForRegistrationDto userForRegistration);
    Task<Guid> Create(UserForAdminManipulationDto userForAdminManipulation, Guid userId);
    Task<UserDetailsWithTokensDto> Authenticate(AuthenticationDto authenticationDto, bool checkIfCanLoginToPortal);
    Task<UserDetailsWithTokensDto> Refresh(TokensDto tokensDto);
    IEnumerable<PermissionDto> GetAllPermissions();
    Task<PagedList<UserDto>> GetByParameters(UsersParameters usersParameters);
    Task<UserDetailsDto> GetById(Guid id);
    Task Update(Guid id, UserForAdminManipulationDto userForAdminManipulation, Guid userId);
    Task UpdateLoggedIn(Guid id, UserForManipulationDto userForManipulation);
    Task ChangePassword(Guid id, ChangePasswordDto changePasswordDto, Guid userId);
    Task Delete(Guid id, Guid userId);
    Task<IEnumerable<RoleDto>> GetAllRoles();
    Task<RoleDto> GetRoleByIdOrDescription(Guid? id, string? description);
    Task<Guid> CreateRole(RoleForManipulationDto roleForManipulation, Guid userId);
    Task UpdateRole(Guid id, RoleForManipulationDto roleForManipulation, Guid userId);
    Task DeleteRole(Guid id, Guid userId);
    Task SetPassword(Guid id, string newPassword);
    Task ForgotPassword(ForgotPasswordDto forgotPasswordDto);
    Task<Guid> CreateLocation(UserLocationForManipulationDto userLocationForManipulation, Guid userId);
    Task<IEnumerable<UserLocationDto>> GetMyLocations(Guid userId);
    Task UpdateLocation(Guid id, UserLocationForManipulationDto userLocationForManipulation, Guid userId);
    Task DeleteLocation(Guid id, Guid userId);
}