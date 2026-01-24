using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Domain.Helpers;

public static class EnumHelper
{
    public static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attr = field?.GetCustomAttribute<DisplayAttribute>();
        return attr?.Description ?? value.ToString();
    }
}