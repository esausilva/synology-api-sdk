using System.Text.Json.Serialization;
using Synology.Api.Sdk.Constants;
using Synology.Api.Sdk.Extensions;
using Synology.Api.Sdk.SynologyApi.Shared.Request;

namespace Synology.Api.Sdk.SynologyApi.Foto.Request;

public sealed class FotoBrowseAlbumRequest : RequestBase
{
    [JsonPropertyName("offset")]
    public int Offset { get; }
    
    [JsonPropertyName("limit")]
    public int Limit { get; }
    
    [JsonPropertyName("SynoToken")]
    public string SynoToken { get; }
    
    /// <summary>
    /// Represents a request to retrieve a list of albums in your Personal Space.
    /// <br/><br/>
    /// <b>Target API</b>: SYNO.Foto.Browse.Album   
    /// </summary>
    /// <exception cref="ArgumentException">
    /// Thrown if the <paramref name="version"/> parameter is zero or negative.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown if the <paramref name="method"/> parameter is <c>null</c> or white space.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown if the <paramref name="offset"/> parameter is negative.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown if the <paramref name="limit"/> parameter is negative.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown if the <paramref name="synoToken"/> parameter is <c>null</c> or white space.
    /// </exception>
    public FotoBrowseAlbumRequest(int version, string method, int offset, int limit, string synoToken) 
        : base(SynologyApis.Foto.BrowseAlbum, version, method)
    {
        offset.ThrowIfNegative(nameof(offset));
        limit.ThrowIfNegative(nameof(limit));
        ArgumentException.ThrowIfNullOrWhiteSpace(synoToken, nameof(synoToken));
        
        Offset = offset;
        Limit = limit;
        SynoToken = synoToken;
    }
}