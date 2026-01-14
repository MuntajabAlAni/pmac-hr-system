using System.Reflection;
using Entities.Attributes;

namespace Shared.Helpers;

public class ModelComparer<T> where T : class
{
    public IEnumerable<PropertyChange> Compare(T? oldModel, T? newModel)
    {
        if (oldModel == null || newModel == null)
        {
            return new List<PropertyChange>();
        }

        return (from property in typeof(T).GetProperties()
            where !Attribute.IsDefined(property, typeof(IgnoreChangeAttribute))
            let oldValueRaw = property.GetValue(oldModel)
            let newValueRaw = property.GetValue(newModel)
            where !Equals(oldValueRaw, newValueRaw)
            let displayName = property.GetCustomAttribute<DisplayNameAttribute>()?.Name ?? property.Name
            select new PropertyChange
            {
                PropertyName = displayName, OldValue = FormatValue(oldValueRaw), NewValue = FormatValue(newValueRaw)
            }).ToList();
    }

    private static string? FormatValue(object? value)
    {
        return value switch
        {
            bool b => b ? "نعم" : "لا",
            double d => d.ToString("G"),
            float f => f.ToString("G"),
            decimal m => m.ToString("G"),
            _ => value?.ToString()
        };
    }
}

public class PropertyChange
{
    public string? PropertyName { get; set; }
    public string? OldValue { get; set; }
    public string? NewValue { get; set; }
}