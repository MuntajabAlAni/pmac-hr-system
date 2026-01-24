using Domain.Models;
using Domain.RequestFeatures;

namespace Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> FindByIdOrEmail(Guid? id = null, string? email = null);
    Task<Guid> Create(User userForCreation);
    Task<(IEnumerable<User>, int)> FindByParameters(UsersParameters usersParameters);
    Task Update(User user);
    Task UpdateFcmTokenById(Guid id, string fcmToken);
    Task UpdatePasswordById(Guid id, string newPassword);
    Task Delete(Guid id);
    Task UpdateRefreshToken(Guid userId, string refreshToken, DateTime refreshTokenExpiryTime);
    Task<IEnumerable<Role>> FindAllRoles();
    Task<Role?> FindRoleById(Guid? id = null, string? description = null);
    Task<Guid> CreateRole(Role roleForCreation);
    Task UpdateRole(Guid id, Role role);
    Task DeleteRole(Guid id);
    Task<string?> GetUserFcmTokenById(Guid id);
    Task UpdateAccessTokenById(Guid id, string accessToken);
    Task<string?> GetUserAccessTokenById(Guid id);
    Task UpdateLoggedIn(User newUser);
    Task<IEnumerable<UserLocation>> FindLocationsByUserId(Guid userId);
    Task<UserLocation?> FindLocationById(Guid id);
    Task<Guid> CreateLocation(UserLocation userLocation);
    Task UpdateLocation(UserLocation userLocation);
    Task DeleteLocation(Guid id);
}