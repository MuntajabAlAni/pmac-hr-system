using System.ComponentModel.DataAnnotations;

namespace Entities.Enums;

public enum Permission
{
    [Display(Name = "Super Admin", Description = "SuperAdmin")] SuperAdmin,
    [Display(Name = "Add User", Description = "Add.Users")] AddUser,
    [Display(Name = "View User", Description = "View.Users")] ViewUser,
    [Display(Name = "Edit User", Description = "Edit.Users")] EditUser,
    [Display(Name = "Delete User", Description = "Delete.Users")] DeleteUser,

    [Display(Name = "Add Role", Description = "Add.Roles")] AddRole,
    [Display(Name = "View Role", Description = "View.Roles")] ViewRole,
    [Display(Name = "Edit Role", Description = "Edit.Roles")] EditRole,
    [Display(Name = "Delete Role", Description = "Delete.Roles")] DeleteRole,

    [Display(Name = "Login To Portal", Description = "LoginToPortal")] LoginToPortal,
}