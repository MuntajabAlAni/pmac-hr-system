using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Shared.DataTransferObjects;
using Shared.Helpers;
using Shared.RequestFeatures;

namespace PmacHrSystem.Presentation.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController(IServiceManager service) : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult<Guid>> RegisterUser(UserForRegistrationDto userForRegistration)
    {
        var id = await service.UserService.Register(userForRegistration);
        return id != Guid.Empty ? Ok(id) : BadRequest();
    }

    [Authorize(Roles = "Add.Users, SuperAdmin")]
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateUser(UserForAdminManipulationDto userForAdminManipulation)
    {
        var userId = User.RetrieveUserIdFromPrincipal();
        var id = await service.UserService.Create(userForAdminManipulation, userId);
        return id != Guid.Empty ? Ok(id) : BadRequest();
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDetailsWithTokensDto>> UserAuthenticate(
        [FromBody] AuthenticationDto authenticationDto)
    {
        var tokens = await service.UserService.Authenticate(authenticationDto, false);
        return Ok(tokens);
    }

    [HttpPost("login/admin-panel")]
    public async Task<ActionResult<UserDetailsWithTokensDto>> AdminAuthenticate(
        [FromBody] AuthenticationDto authenticationDto)
    {
        var tokens = await service.UserService.Authenticate(authenticationDto, true);
        return Ok(tokens);
    }

    [HttpPost("refresh")]
    public async Task<ActionResult<UserDetailsWithTokensDto>> Refresh([FromBody] TokensDto tokensDto)
    {
        var tokens = await service.UserService.Refresh(tokensDto);
        return Ok(tokens);
    }

    [Authorize(Roles = "View.Roles, SuperAdmin")]
    [HttpGet("permissions")]
    public ActionResult<IEnumerable<PermissionDto>> GetAllPermissions()
    {
        var permissions = service.UserService.GetAllPermissions();
        return Ok(permissions);
    }

    [Authorize(Roles = "View.Roles, SuperAdmin")]
    [HttpGet("roles")]
    public async Task<ActionResult<IEnumerable<RoleDto>>> GetAllRoles()
    {
        var roles = await service.UserService.GetAllRoles();
        return Ok(roles);
    }

    [Authorize(Roles = "View.Roles, SuperAdmin")]
    [HttpGet("role")]
    public async Task<ActionResult<RoleDto>> GetRoleByIdOrDescription(Guid? id, string? description)
    {
        var role = await service.UserService.GetRoleByIdOrDescription(id, description);
        return Ok(role);
    }

    [Authorize(Roles = "Add.Roles, SuperAdmin")]
    [HttpPost("role")]
    public async Task<ActionResult<int>> CreateRole([FromBody] RoleForManipulationDto roleForManipulation)
    {
        var userId = User.RetrieveUserIdFromPrincipal();
        var id = await service.UserService.CreateRole(roleForManipulation, userId);
        return id != Guid.Empty ? Ok(id) : BadRequest();
    }

    [Authorize(Roles = "Edit.Roles, SuperAdmin")]
    [HttpPut("role/{id:Guid}")]
    public async Task<IActionResult> UpdateRole(Guid id, [FromBody] RoleForManipulationDto roleForManipulation)
    {
        var userId = User.RetrieveUserIdFromPrincipal();
        await service.UserService.UpdateRole(id, roleForManipulation, userId);
        return NoContent();
    }

    [Authorize(Roles = "Delete.Roles, SuperAdmin")]
    [HttpDelete("role/{id:Guid}")]
    public async Task<IActionResult> DeleteRole(Guid id)
    {
        var userId = User.RetrieveUserIdFromPrincipal();
        await service.UserService.DeleteRole(id, userId);
        return NoContent();
    }

    [Authorize(Roles = "View.Users, SuperAdmin")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsersByParameters(
        [FromQuery] UsersParameters usersParameters)
    {
        var users = await service.UserService.GetByParameters(usersParameters);
        Response.Headers["X-Pagination"] = JsonSerializer.Serialize(users.MetaData);
        return Ok(users);
    }

    [Authorize(Roles = "View.Users, SuperAdmin")]
    [HttpGet("{id:Guid}")]
    public async Task<ActionResult<UserDetailsDto>> GetUserById(Guid id)
    {
        var user = await service.UserService.GetById(id);
        return Ok(user);
    }

    [Authorize]
    [HttpGet("logged-in-user")]
    public async Task<ActionResult<UserDetailsDto>> GetLoggedInUserDto()
    {
        var id = User.RetrieveUserIdFromPrincipal();
        var user = await service.UserService.GetById(id);
        return Ok(user);
    }

    [Authorize(Roles = "Edit.Users, SuperAdmin")]
    [HttpPut("{id:Guid}")]
    public async Task<ActionResult> UpdateUser(Guid id, UserForAdminManipulationDto userForAdminManipulation)
    {
        var userId = User.RetrieveUserIdFromPrincipal();
        await service.UserService.Update(id, userForAdminManipulation, userId);
        return NoContent();
    }

    [Authorize]
    [HttpPut("logged-in-user")]
    public async Task<ActionResult> UpdateUser(UserForManipulationDto userForManipulationDto)
    {
        var id = User.RetrieveUserIdFromPrincipal();
        await service.UserService.UpdateLoggedIn(id, userForManipulationDto);
        return NoContent();
    }

    [Authorize(Roles = "Edit.Users, SuperAdmin")]
    [HttpPut("{id:Guid}/change-password")]
    public async Task<ActionResult> ChangeUserPassword(Guid id, ChangePasswordDto changePasswordDto)
    {
        var userId = User.RetrieveUserIdFromPrincipal();
        await service.UserService.ChangePassword(id, changePasswordDto, userId);
        return NoContent();
    }

    [HttpPut("forgot-password")]
    public async Task<ActionResult> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
    {
        await service.UserService.ForgotPassword(forgotPasswordDto);
        return NoContent();
    }

    [Authorize(Roles = "Set.Password, SuperAdmin")]
    [HttpPut("set-password")]
    public async Task<ActionResult> SetUserPassword(string newPassword)
    {
        var userId = User.RetrieveUserIdFromPrincipal();
        await service.UserService.SetPassword(userId, newPassword);
        return NoContent();
    }

    [Authorize]
    [HttpPut("logged-in-change-password")]
    public async Task<ActionResult> ChangeLoggedInUserPassword(ChangePasswordDto changePasswordDto)
    {
        var id = User.RetrieveUserIdFromPrincipal();
        await service.UserService.ChangePassword(id, changePasswordDto, id);
        return NoContent();
    }

    [Authorize(Roles = "Delete.Users, SuperAdmin")]
    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult> DeleteUser(Guid id)
    {
        var userId = User.RetrieveUserIdFromPrincipal();
        await service.UserService.Delete(id, userId);
        return NoContent();
    }

    [Authorize]
    [HttpPost("my-locations")]
    public async Task<ActionResult<IEnumerable<UserLocationDto>>> CreateLocation(UserLocationForManipulationDto userLocationForManipulation)
    {
        var userId = User.RetrieveUserIdFromPrincipal();
        var id = await service.UserService.CreateLocation(userLocationForManipulation, userId);
        return id != Guid.Empty ? Ok(id) : BadRequest();
    }

    [Authorize]
    [HttpGet("my-locations")]
    public async Task<ActionResult<IEnumerable<UserLocationDto>>> GetMyLocations()
    {
        var userId = User.RetrieveUserIdFromPrincipal();
        var locations = await service.UserService.GetMyLocations(userId);
        return Ok(locations);
    }

    [Authorize]
    [HttpPut("my-locations/{id:Guid}")]
    public async Task<ActionResult<IEnumerable<UserLocationDto>>> UpdateMyLocation(Guid id, UserLocationForManipulationDto userLocationForManipulation)
    {
        var userId = User.RetrieveUserIdFromPrincipal();
        await service.UserService.UpdateLocation(id, userLocationForManipulation, userId);
        return NoContent();
    }

    [Authorize]
    [HttpDelete("my-locations/{id:Guid}")]
    public async Task<ActionResult<IEnumerable<UserLocationDto>>> DeleteMyLocation(Guid id)
    {
        var userId = User.RetrieveUserIdFromPrincipal();
        await service.UserService.DeleteLocation(id, userId);
        return NoContent();
    }
}