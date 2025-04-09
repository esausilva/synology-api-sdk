using System.Text.Json.Serialization;
using Synology.Api.Sdk.Constants;
using Synology.Api.Sdk.SynologyApi.Shared.Request;

namespace Synology.Api.Sdk.SynologyApi.FotoTeam.Request;

public sealed class FotoTeamSearchSearchRequest : RequestBase
{
    [JsonPropertyName("SynoToken")]
    public string SynoToken { get; }

    [JsonPropertyName("keyword")]
    public string Keyword { get; }
    
    /// <summary>
    /// Represents a request to retrieve a count of items based on a keyword in the Shared Space.
    /// <br/><br/>
    /// <b>Target API</b>: SYNO.FotoTeam.Search.Search
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
    /// Thrown if the <paramref name="keyword"/> parameter is <c>null</c> or white space.
    /// </exception>
    public FotoTeamSearchSearchRequest(int version, string method, string synoToken, string keyword)
        : base(SynologyApis.FotoTeamSearchSearch, version, method)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(synoToken, nameof(synoToken));
        ArgumentException.ThrowIfNullOrWhiteSpace(keyword, nameof(keyword));
        
        SynoToken = synoToken;
        Keyword = keyword;
    }
}