using System.ComponentModel.DataAnnotations;

namespace Synology.Api.Sdk.Extensions;

public static class EnumExtensions
{
    public static string? GetDisplayName<T>(this T value) where T : Enum
    {
        var fieldInfo = value.GetType().GetField(value.ToString());
        var displayAttribute = fieldInfo?.GetCustomAttributes(typeof(DisplayAttribute), false)
            .FirstOrDefault() as DisplayAttribute;
     
        return displayAttribute?.Name;
    }
}