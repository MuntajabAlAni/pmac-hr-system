using Dapper;
using Domain.Enums;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Queries;
using Domain.RequestFeatures;

namespace Infrastructure.Repositories;

public class UserRepository(DapperContext context) : IUserRepository
{
    public async Task<User?> FindByIdOrEmail(Guid? id = null, string? email = null)
    {
        const string query = UserQueries.ByEmailOrIdQuery;
        const string additionalPermissionsQuery = UserQueries.UserAdditionalPermissionsByIdQuery;
        const string roleQuery = UserQueries.RoleByDescriptionOrIdQuery;
        const string rolePermissionsQuery = UserQueries.RolePermissionsByIdQuery;

        using var connection = context.CreateConnection();
        connection.Open();

        var user = await connection.QueryFirstOrDefaultAsync<User>(query,
            new { Id = id, Email = email });

        if (user is null) return user;

        user.AdditionalPermissions =
            (await connection.QueryAsync<Permission>(additionalPermissionsQuery, new { user.Id })).ToList();
        user.Role = await connection.QueryFirstAsync<Role>(roleQuery,
            new { Id = user.RoleId, Description = string.Empty });
        user.Role.Permissions =
            (await connection.QueryAsync<Permission>(rolePermissionsQuery, new { Id = user.RoleId })).ToList();

        return user;
    }

    public async Task<Guid> Create(User user)
    {
        const string query = UserQueries.InsertQuery;
        const string permissionsQuery = UserQueries.InsertUserAdditionalPermissionsQuery;

        using var connection = context.CreateConnection();
        connection.Open();

        user.Id = Guid.CreateVersion7();
        var param = new DynamicParameters(user);

        using var trans = connection.BeginTransaction();
        await connection.ExecuteAsync(query, param, transaction: trans);
        var id = user.Id;

        foreach (var permission in user.AdditionalPermissions)
        {
            await connection.ExecuteAsync(permissionsQuery, new { Permission = permission, UserId = id },
                transaction: trans);
        }

        trans.Commit();
        return id;
    }

    public async Task<(IEnumerable<User>, int)> FindByParameters(UsersParameters usersParameters)
    {
        const string query = UserQueries.ByParametersQuery;
        const string countQuery = UserQueries.CountByParametersQuery;
        const string roleQuery = UserQueries.RoleByDescriptionOrIdQuery;
        const string rolePermissionsQuery = UserQueries.RolePermissionsByIdQuery;

        var skip = (usersParameters.PageNumber - 1) * usersParameters.PageSize;
        var param = new DynamicParameters(usersParameters);
        param.Add("Skip", skip);

        using var connection = context.CreateConnection();
        connection.Open();

        var count = await connection.QueryFirstOrDefaultAsync<int>(countQuery, param);
        var users = await connection.QueryAsync<User>(query, param);

        foreach (var user in users)
        {
            user.Role = await connection.QueryFirstAsync<Role>(roleQuery,
                new { Id = user.RoleId, Description = string.Empty });
            user.Role.Permissions =
                (await connection.QueryAsync<Permission>(rolePermissionsQuery, new { Id = user.RoleId })).ToList();
        }

        return (users, count);
    }

    public async Task Update(User user)
    {
        const string query = UserQueries.UpdateByIdQuery;
        const string deletePermissionsQuery = UserQueries.DeleteUserAdditionalPermissionsByIdQuery;
        const string permissionsQuery = UserQueries.InsertUserAdditionalPermissionsQuery;

        var param = new DynamicParameters(user);

        using var connection = context.CreateConnection();
        connection.Open();

        using var trans = connection.BeginTransaction();
        await connection.ExecuteAsync(query, param, transaction: trans);
        await connection.ExecuteAsync(deletePermissionsQuery, new { user.Id }, transaction: trans);

        foreach (var permission in user.AdditionalPermissions)
        {
            await connection.ExecuteAsync(permissionsQuery, new { Permission = permission, UserId = user.Id },
                transaction: trans);
        }

        trans.Commit();
    }

    public async Task UpdateFcmTokenById(Guid id, string fcmToken)
    {
        const string query = UserQueries.UpdateFcmTokenQuery;

        var param = new DynamicParameters();
        param.Add("Id", id);
        param.Add("FcmToken", fcmToken);

        using var connection = context.CreateConnection();
        connection.Open();

        await connection.ExecuteAsync(query, param);
    }


    public async Task UpdatePasswordById(Guid id, string newPassword)
    {
        const string query = UserQueries.UpdatePasswordByIdQuery;
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(query, new { Id = id, NewPassword = newPassword });
    }

    public async Task Delete(Guid id)
    {
        const string query = UserQueries.DeleteByIdQuery;
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(query, new { Id = id });
    }

    public async Task UpdateRefreshToken(Guid id, string refreshToken, DateTime refreshTokenExpiryTime)
    {
        const string query = UserQueries.UpdateRefreshTokenByIdQuery;

        using var connection = context.CreateConnection();
        connection.Open();

        await connection.ExecuteAsync(query,
            new { Id = id, RefreshToken = refreshToken, RefreshTokenExpiryTime = refreshTokenExpiryTime });
    }

    public async Task<IEnumerable<Role>> FindAllRoles()
    {
        const string query = UserQueries.AllRolesQuery;
        const string permissionsQuery = UserQueries.RolePermissionsByIdQuery;

        using var connection = context.CreateConnection();
        var roles = (await connection.QueryAsync<Role>(query)).ToList();

        foreach (var role in roles)
        {
            role.Permissions = (await connection.QueryAsync<Permission>(permissionsQuery, new { role.Id })).ToList();
        }

        return roles;
    }

    public async Task<Role?> FindRoleById(Guid? id = null, string? description = null)
    {
        const string query = UserQueries.RoleByDescriptionOrIdQuery;
        const string permissionsQuery = UserQueries.RolePermissionsByIdQuery;

        using var connection = context.CreateConnection();
        connection.Open();

        var role = await connection.QueryFirstOrDefaultAsync<Role>(query,
            new { Id = id, Description = description });

        if (role is not null)
            role.Permissions = (await connection.QueryAsync<Permission>(permissionsQuery, new { role.Id })).ToList();

        return role;
    }

    public async Task<Guid> CreateRole(Role roleForCreation)
    {
        const string query = UserQueries.InsertRoleQuery;
        const string permissionsQuery = UserQueries.InsertRolePermissionsQuery;

        var param = new DynamicParameters(roleForCreation);

        using var connection = context.CreateConnection();
        connection.Open();

        roleForCreation.Id = Guid.CreateVersion7();
        param.Add("Id", roleForCreation.Id);

        using var trans = connection.BeginTransaction();
        await connection.ExecuteAsync(query, param, transaction: trans);
        var id = roleForCreation.Id;

        foreach (var permission in roleForCreation.Permissions)
        {
            await connection.ExecuteAsync(permissionsQuery, new { Permission = permission, RoleId = id },
                transaction: trans);
        }

        trans.Commit();
        return id;
    }

    public async Task UpdateRole(Guid id, Role role)
    {
        const string query = UserQueries.UpdateRoleByIdQuery;
        const string deletePermissionsQuery = UserQueries.DeleteRolePermissionsByIdQuery;
        const string permissionsQuery = UserQueries.InsertRolePermissionsQuery;

        var param = new DynamicParameters(role);
        param.Add("Id", id);

        using var connection = context.CreateConnection();
        connection.Open();

        using var trans = connection.BeginTransaction();
        await connection.ExecuteAsync(query, param, transaction: trans);
        await connection.ExecuteAsync(deletePermissionsQuery, new { Id = id }, transaction: trans);

        foreach (var permission in role.Permissions)
        {
            await connection.ExecuteAsync(permissionsQuery, new { Permission = permission, RoleId = id },
                transaction: trans);
        }

        trans.Commit();
    }

    public async Task DeleteRole(Guid id)
    {
        const string query = UserQueries.DeleteRoleByIdQuery;
        const string deletePermissionsQuery = UserQueries.DeleteRolePermissionsByIdQuery;

        using var connection = context.CreateConnection();
        connection.Open();

        using var trans = connection.BeginTransaction();
        await connection.ExecuteAsync(deletePermissionsQuery, new { Id = id }, transaction: trans);
        await connection.ExecuteAsync(query, new { Id = id }, transaction: trans);
        trans.Commit();
    }

    public async Task<string?> GetUserFcmTokenById(Guid id)
    {
        const string query = UserQueries.FcmTokenByIdQuery;

        using var connection = context.CreateConnection();
        var deviceId = await connection.QueryFirstOrDefaultAsync<string>(query, new { Id = id });

        return deviceId;
    }

    public async Task UpdateAccessTokenById(Guid id, string accessToken)
    {
        const string query = UserQueries.UpdateAccessTokenQuery;

        var param = new DynamicParameters();
        param.Add("Id", id);
        param.Add("AccessToken", accessToken);

        using var connection = context.CreateConnection();
        connection.Open();

        await connection.ExecuteAsync(query, param);
    }

    public async Task<string?> GetUserAccessTokenById(Guid id)
    {
        const string query = UserQueries.AccessTokenByIdQuery;

        using var connection = context.CreateConnection();
        var accessToken = await connection.QueryFirstOrDefaultAsync<string>(query, new { Id = id });

        return accessToken;
    }

    public async Task UpdateLoggedIn(User user)
    {
        const string query = UserQueries.UpdateLoggedInByIdQuery;

        var param = new DynamicParameters(user);

        using var connection = context.CreateConnection();
        connection.Open();

        using var trans = connection.BeginTransaction();
        await connection.ExecuteAsync(query, param, transaction: trans);

        trans.Commit();
    }


    public async Task<IEnumerable<UserLocation>> FindLocationsByUserId(Guid userId)
    {
        const string query = UserQueries.LocationsByUserIdQuery;
        using var connection = context.CreateConnection();
        connection.Open();
        var locations = await connection.QueryAsync<UserLocation>(query, new { UserId = userId });
        return locations;
    }

    public async Task<UserLocation?> FindLocationById(Guid id)
    {
        const string query = UserQueries.LocationByIdQuery;
        using var connection = context.CreateConnection();
        connection.Open();
        var location = await connection.QueryFirstOrDefaultAsync<UserLocation>(query, new { Id = id });
        return location;
    }

    public async Task<Guid> CreateLocation(UserLocation userLocation)
    {
        const string query = UserQueries.InsertLocationQuery;
        using var connection = context.CreateConnection();
        connection.Open();
        userLocation.Id = Guid.CreateVersion7();
        await connection.ExecuteAsync(query, userLocation);
        return userLocation.Id;
    }

    public async Task UpdateLocation(UserLocation userLocation)
    {
        const string query = UserQueries.UpdateLocationByIdQuery;
        using var connection = context.CreateConnection();
        connection.Open();
        await connection.ExecuteAsync(query, userLocation);
    }

    public async Task DeleteLocation(Guid id)
    {
        const string query = UserQueries.DeleteLocationByIdQuery;
        using var connection = context.CreateConnection();
        connection.Open();
        await connection.ExecuteAsync(query, new { Id = id });
    }
}
