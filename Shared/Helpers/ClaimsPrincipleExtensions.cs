using System.Security.Claims;

namespace Shared.Helpers;

public static class ClaimsPrincipleExtensions
{
    public static Guid RetrieveUserIdFromPrincipal(this ClaimsPrincipal user)
    {
        return Guid.Parse(user.FindFirst(ClaimTypes.NameIdentifier)!.Value);
    }
    public static Guid RetrieveProviderIdFromPrincipal(this ClaimsPrincipal user)
    {
        return Guid.Parse(user.FindFirst(ClaimTypes.GroupSid)!.Value);
    }

    public static string RetrieveUserNameFromPrincipal(this ClaimsPrincipal user)
    {
        return user.FindFirst(ClaimTypes.Name)!.Value;
    }
}