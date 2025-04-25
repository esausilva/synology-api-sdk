using System.Text.Json.Serialization;
using Synology.Api.Sdk.Constants;
using Synology.Api.Sdk.Extensions;
using Synology.Api.Sdk.SynologyApi.Shared.Request;

namespace Synology.Api.Sdk.SynologyApi.FotoTeam.Request;

public sealed class FotoTeamBrowseFolderRequest : RequestBase
{
    [JsonPropertyName("SynoToken")]
    public string SynoToken { get; }

    [JsonPropertyName("offset")]
    public int Offset { get; }
    
    [JsonPropertyName("limit")]
    public int Limit { get; }

    [JsonPropertyName("id")]
    public int? Id { get; }
    
    /// <summary>
    /// Represents a request to retrieve a list of folders in the Shared Space.
    /// <br/><br/>
    /// <b>Target API</b>: SYNO.FotoTeam.Browse.Folder
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
    /// Thrown if the <paramref name="offset"/> parameter is negative.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown if the <paramref name="limit"/> parameter is negative.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown if the <paramref name="id"/> parameter is negative.
    /// </exception>
    public FotoTeamBrowseFolderRequest(int version, string method, string synoToken, int offset = 0, 
        int limit = 100, int? id = null)
        : base(SynologyApis.FotoTeam.BrowseFolder, version, method)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(synoToken, nameof(synoToken));
        offset.ThrowIfNegative(nameof(offset));
        limit.ThrowIfNegative(nameof(limit));
        id?.ThrowIfNegative(nameof(id));

        SynoToken = synoToken;
        Offset = offset;
        Limit = limit;
        Id = id;
    }
}