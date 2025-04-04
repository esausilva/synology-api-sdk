namespace Synology.Api.Sdk.Extensions;

internal static class DictionaryExtensions
{
    public static void Merge<TKey, TValue>(this Dictionary<TKey, TValue> value, 
        IReadOnlyDictionary<TKey, TValue> merge)
        where TKey : notnull 
        where TValue : notnull
    {
        foreach (var item in merge)
        {
            value.Add(item.Key, item.Value);
        }
    }
}