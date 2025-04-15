using System.Text.Json.Serialization;
using Synology.Api.Sdk.Constants;
using Synology.Api.Sdk.Extensions;
using Synology.Api.Sdk.SynologyApi.Shared.Request;

namespace Synology.Api.Sdk.SynologyApi.FotoTeam.Request;

public sealed class FotoTeamThumbnailRequest : RequestBase
{
    [JsonPropertyName("SynoToken")]
    public string SynoToken { get; }

    [JsonPropertyName("id")]
    public int Id { get; }

    [JsonPropertyName("cache_key")]
    public string CacheKey { get; }
    
    [JsonPropertyName("type")]
    public string Type { get; }
    
    [JsonPropertyName("size")]
    public string Size { get; }
    
    /// <summary>
    /// Represents a request to download an item's thumbnail in the Shared Space.
    /// <br/><br/>
    /// <b>Target API</b>: SYNO.FotoTeam.Thumbnail
    /// </summary>
    /// <exception cref="ArgumentException">
    /// Thrown if the <paramref name="version"/> parameter is zero or negative.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown if the <paramref name="method"/> parameter is <c>null</c> or white space.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown if the <paramref name="synoToken"/> parameter is <c>null</c> or white space.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown if the <paramref name="id"/> parameter is negative.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown if the <paramref name="cacheKey"/> parameter is <c>null</c> or white space.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown if the <paramref name="type"/> parameter is <c>null</c> or white space.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown if the <paramref name="size"/> parameter is <c>null</c> or white space.
    /// </exception>
    public FotoTeamThumbnailRequest(int version, string method, string synoToken, int id, string cacheKey, 
        string type, string size)
        : base(SynologyApis.FotoTeamThumbnail, version, method)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(synoToken, nameof(synoToken));
        ArgumentException.ThrowIfNullOrWhiteSpace(cacheKey, nameof(cacheKey));
        ArgumentException.ThrowIfNullOrWhiteSpace(type, nameof(type));
        ArgumentException.ThrowIfNullOrWhiteSpace(size, nameof(size));
        id.ThrowIfNegative(nameof(id));

        SynoToken = synoToken;
        Id = id;
        CacheKey = cacheKey;
        Type = type;
        Size = size;
    }
}