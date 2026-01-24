using Application.DataTransferObjects;
using Domain.RequestFeatures;

namespace Application.Interfaces;

public interface IUserService
{
    Task<Guid> Create(UserForAdminManipulationDto userForAdminManipulation, Guid userId);
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
    Task<Guid> CreateLocation(UserLocationForManipulationDto userLocationForManipulation, Guid userId);
    Task<IEnumerable<UserLocationDto>> GetMyLocations(Guid userId);
    Task UpdateLocation(Guid id, UserLocationForManipulationDto userLocationForManipulation, Guid userId);
    Task DeleteLocation(Guid id, Guid userId);
}