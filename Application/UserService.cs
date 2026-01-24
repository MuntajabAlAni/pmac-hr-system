using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.Interfaces;
using Application.DataTransferObjects;
using Domain.Helpers;
using Domain.RequestFeatures;
using Domain.SeededData;
using Action = Domain.Enums.Action;

namespace Application.Services;

public class UserService(
    IRepositoryManager repositoryManager,
    IMapper mapper)
    : IUserService
{
    public async Task<Guid> Create(UserForAdminManipulationDto userForCreate, Guid userId)
    {
        var userForCreation = mapper.Map<User>(userForCreate);
        await Validate(userForCreation);

        userForCreation.AddedByUserId = userId;
        userForCreation.Password = userForCreate.Password.HashPassword();
        var id = await repositoryManager.User.Create(userForCreation);

        return id;
    }

    private async Task Validate(User user, Guid? id = null)
    {
        switch (user.PhoneNumber.Length)
        {
            case < 11:
                throw new StringLimitBadRequestException("رقم الهاتف", 11, false);
            case > 11:
                throw new StringLimitBadRequestException("رقم الهاتف", 11, true);
        }

        if (!user.PhoneNumber.StartsWith("077") &&
            !user.PhoneNumber.StartsWith("078") &&
            !user.PhoneNumber.StartsWith("079"))
            throw new NotIraqiPhoneNumberBadRequestException();

        if (user.FullName.Length < 2)
            throw new StringLimitBadRequestException("الإسم", 2, false);

        var anyUserSameEmail = await repositoryManager.User.FindByIdOrEmail(id, user.Email);
        if (anyUserSameEmail is not null && (id is null || id == Guid.Empty || anyUserSameEmail.Id != id))
            throw new AlreadyExistBadRequestException("البريد الإلكتروني ", user.Email);

        var role = await repositoryManager.User.FindRoleById(user.RoleId);
        if (role is null)
            throw new EntityNotFoundException("الدور", "المعرف", user.RoleId);

        user.AdditionalPermissions = user.AdditionalPermissions.Except(role.Permissions).ToList();
    }

    public IEnumerable<PermissionDto> GetAllPermissions()
    {
        var permissions = Enum.GetValues(typeof(Permission))
            .Cast<Permission>()
            .Select(permission => mapper.Map<PermissionDto>(permission));

        return permissions;
    }

    public async Task<PagedList<UserDto>> GetByParameters(UsersParameters usersParameters)
    {
        var (users, count) = await repositoryManager.User.FindByParameters(usersParameters);
        var usersDto = mapper.Map<List<UserDto>>(users);

        var userDtoPagedList = new PagedList<UserDto>(usersDto, count,
            usersParameters.PageNumber, usersParameters.PageSize);

        return userDtoPagedList;
    }

    public async Task<UserDetailsDto> GetById(Guid id)
    {
        var user = await repositoryManager.User.FindByIdOrEmail(id);

        if (user is null)
            throw new EntityNotFoundException("المستخدم", "المعرف", id);

        var userDto = mapper.Map<UserDetailsDto>(user);
        return userDto;
    }

    public async Task Update(Guid id, UserForAdminManipulationDto userForAdminManipulation, Guid userId)
    {
        var oldUser = await repositoryManager.User.FindByIdOrEmail(id);
        if (oldUser is null)
            throw new EntityNotFoundException("المستخدم", "المعرف", id);

        var newUser = mapper.Map<UserForAdminManipulationDto, User>(userForAdminManipulation);

        await Validate(newUser, id);

        newUser.Id = id;
        await repositoryManager.User.Update(newUser);
    }

    public async Task UpdateLoggedIn(Guid id, UserForManipulationDto userForManipulation)
    {
        var oldUser = await repositoryManager.User.FindByIdOrEmail(id);
        if (oldUser is null)
            throw new EntityNotFoundException("المستخدم", "المعرف", id);

        var newUser = mapper.Map<UserForManipulationDto, User>(userForManipulation);

        newUser.RoleId = oldUser.RoleId;
        await Validate(newUser, id);

        newUser.Id = id;
        await repositoryManager.User.UpdateLoggedIn(newUser);

        var comparer = new ModelComparer<User>();
        var differences = comparer.Compare(oldUser, newUser);
    }

    public async Task ChangePassword(Guid id, ChangePasswordDto changePasswordDto, Guid userId)
    {
        var user = await repositoryManager.User.FindByIdOrEmail(id);
        if (user is null)
            throw new EntityNotFoundException("المستخدم", "المعرف", id);

        if (id != userId)
        {
            var adminUser = await repositoryManager.User.FindByIdOrEmail(userId);
            if (adminUser is null)
                throw new EntityNotFoundException("المستخدم المدير", "المعرف", userId);

            var verified = changePasswordDto.LoggedInUserPassword.VerifyHashedPassword(adminUser.Password);
            if (!verified) throw new InvalidCredentialsUnauthorizedException(adminUser.Email);

            await repositoryManager.User.UpdatePasswordById(id, changePasswordDto.NewPassword.HashPassword());
        }
        else
        {
            var verified = changePasswordDto.LoggedInUserPassword.VerifyHashedPassword(user.Password);
            if (!verified) throw new InvalidCredentialsUnauthorizedException(user.Email);

            await repositoryManager.User.UpdatePasswordById(id, changePasswordDto.NewPassword.HashPassword());
        }
    }

    public async Task Delete(Guid id, Guid userId)
    {
        var user = await repositoryManager.User.FindByIdOrEmail(id);
        if (user is null)
            throw new EntityNotFoundException("المستخدم", "المعرف", id);

        await repositoryManager.User.Delete(id);
    }

    public async Task<IEnumerable<RoleDto>> GetAllRoles()
    {
        var roles = await repositoryManager.User.FindAllRoles();
        var rolesDto = mapper.Map<IEnumerable<RoleDto>>(roles);
        return rolesDto;
    }

    public async Task<RoleDto> GetRoleByIdOrDescription(Guid? id, string? description)
    {
        var role = await repositoryManager.User.FindRoleById(id, description);

        if (role is null)
            throw new EntityNotFoundException("الدور",
                description is null ? "المعرف" : "الوصف",
                description is null ? id!.Value : description);

        var roleDto = mapper.Map<RoleDto>(role);
        return roleDto;
    }

    public async Task<Guid> CreateRole(RoleForManipulationDto roleForManipulation, Guid userId)
    {
        var roleForCreation = mapper.Map<Role>(roleForManipulation);
        await ValidateRole(roleForCreation);
        var id = await repositoryManager.User.CreateRole(roleForCreation);

        return id;
    }

    public async Task UpdateRole(Guid id, RoleForManipulationDto roleForManipulation, Guid userId)
    {
        var oldRole = await repositoryManager.User.FindRoleById(id);
        if (oldRole is null)
            throw new EntityNotFoundException("الدور", "المعرف", id);

        var role = mapper.Map<Role>(roleForManipulation);

        await ValidateRole(role, id);

        role.Id = oldRole.Id;
        await repositoryManager.User.UpdateRole(id, role);

        var comparer = new ModelComparer<Role>();
        var differences = comparer.Compare(oldRole, role);
    }

    public async Task DeleteRole(Guid id, Guid userId)
    {
        var role = await repositoryManager.User.FindRoleById(id);
        if (role is null)
            throw new EntityNotFoundException("الدور", "المعرف", id);

        await repositoryManager.User.DeleteRole(id);
    }

    private async Task ValidateRole(Role role, Guid? id = null)
    {
        if (role.Description.Length < 3)
            throw new StringLimitBadRequestException("الوصف", 3, false);

        if (role.Permissions.Count <= 0)
            throw new RoleShouldHavePermissionsBadRequestException();

        var anyRoleSameDescription = await repositoryManager.User.FindRoleById(role.Id, role.Description);
        if (anyRoleSameDescription is not null && (id is null || id == Guid.Empty || anyRoleSameDescription.Id != id))
            throw new AlreadyExistBadRequestException("وصف الدور ", role.Description);
    }

    public async Task<Guid> CreateLocation(UserLocationForManipulationDto userLocationForManipulation, Guid userId)
    {
        var userLocationForCreation = mapper.Map<UserLocation>(userLocationForManipulation);
        userLocationForCreation.UserId = userId;
        var id = await repositoryManager.User.CreateLocation(userLocationForCreation);
        return id;
    }

    public async Task<IEnumerable<UserLocationDto>> GetMyLocations(Guid userId)
    {
        var userLocations = await repositoryManager.User.FindLocationsByUserId(userId);
        var userLocationsDto = mapper.Map<IEnumerable<UserLocationDto>>(userLocations);
        return userLocationsDto;
    }

    public async Task UpdateLocation(Guid id, UserLocationForManipulationDto userLocationForManipulation, Guid userId)
    {
        var userLocation = await repositoryManager.User.FindLocationById(id);
        if (userLocation is null)
            throw new EntityNotFoundException("الموقع", "المعرف", id);

        if (userLocation.UserId != userId)
            throw new ForbiddenException("Cannot edit location not related to you");

        var userLocationForUpdate = mapper.Map<UserLocation>(userLocationForManipulation);
        userLocationForUpdate.Id = id;
        await repositoryManager.User.UpdateLocation(userLocationForUpdate);
    }

    public async Task DeleteLocation(Guid id, Guid userId)
    {
        var userLocation = await repositoryManager.User.FindLocationById(id);
        if (userLocation is null)
            throw new EntityNotFoundException("الموقع", "المعرف", id);

        if (userLocation.UserId != userId)
            throw new ForbiddenException("Cannot edit location not related to you");

        await repositoryManager.User.DeleteLocation(id);
    }
}