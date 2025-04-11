using System.Collections;

namespace Synology.Api.Sdk.Extensions;

public static class ObjectExtensions
{
    public static bool IsEnumerable(this object? value)
    {
        if (value is null)
            return false;
    
        return value is IEnumerable and not string;
    }
}