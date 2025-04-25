using System.Text.Json.Serialization;
using Synology.Api.Sdk.Constants;
using Synology.Api.Sdk.SynologyApi.Shared.Request;

namespace Synology.Api.Sdk.SynologyApi.FotoTeam.Request;

public sealed class FotoTeamBrowseTimelineRequest : RequestBase
{
    [JsonPropertyName("SynoToken")]
    public string SynoToken { get; }

    /// <summary>
    /// Represents a request to retrieve a list of item counts in the timeline by year and month in the Shared Space. 
    /// <br/><br/>
    /// <b>Target API</b>: SYNO.FotoTeam.Browse.Timeline
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
    public FotoTeamBrowseTimelineRequest(int version, string method, string synoToken)
        : base(SynologyApis.FotoTeam.BrowseTimeline, version, method)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(synoToken, nameof(synoToken));
        
        SynoToken = synoToken;
    }
}