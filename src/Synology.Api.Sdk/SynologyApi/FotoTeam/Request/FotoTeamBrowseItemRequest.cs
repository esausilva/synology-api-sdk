using System.Text.Json.Serialization;
using Synology.Api.Sdk.Constants;
using Synology.Api.Sdk.Extensions;
using Synology.Api.Sdk.SynologyApi.Shared.Request;

namespace Synology.Api.Sdk.SynologyApi.FotoTeam.Request;

public sealed class FotoTeamBrowseItemRequest : RequestBase
{
    [JsonPropertyName("SynoToken")]
    public string SynoToken { get; }

    [JsonPropertyName("offset")]
    public int Offset { get; }
    
    [JsonPropertyName("limit")]
    public int Limit { get; }

    [JsonPropertyName("folder_id")]
    public int? FolderId { get; }

    [JsonPropertyName("additional")]
    public IReadOnlyList<string>? Additional { get; }
    
    /// <summary>
    /// Represents a request to retrieve a list of items within a folder in the Shared Space.
    /// <br/><br/>
    /// <b>Target API</b>: SYNO.FotoTeam.Browse.Item
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
    /// Thrown if the <paramref name="folderId"/> parameter is negative.
    /// </exception>
    public FotoTeamBrowseItemRequest(int version, string method, string synoToken, int offset, 
        int limit, int? folderId = null, IReadOnlyList<string>? additional = null)
        : base(SynologyApis.FotoTeamBrowseItem, version, method)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(synoToken, nameof(synoToken));
        offset.ThrowIfNegative(nameof(offset));
        limit.ThrowIfNegative(nameof(limit));
        folderId?.ThrowIfNegative(nameof(folderId));

        SynoToken = synoToken;
        Offset = offset;
        Limit = limit;
        FolderId = folderId;
        Additional = additional;
    }
}