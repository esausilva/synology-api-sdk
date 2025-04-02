namespace Synology.Api.Sdk.Extensions;

internal static class IntegerExtensions
{
    public static void ThrowIfZeroOrNegative(this int value, string paramName)
    {
        if (value <= 0)
        {
            throw new ArgumentException($"Value cannot be zero or negative. (Parameter '{paramName}')");
        }
    }
}