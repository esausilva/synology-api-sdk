using System.Text.Json.Serialization;
using Synology.Api.Sdk.Constants;
using Synology.Api.Sdk.SynologyApi.Shared.Request;

namespace Synology.Api.Sdk.SynologyApi.FotoTeam.Request;

public sealed class FotoTeamDownloadRequest : RequestBase
{
    [JsonPropertyName("SynoToken")]
    public string SynoToken { get; }

    [JsonPropertyName("unit_id")]
    public IReadOnlyList<int> UnitId { get; }
    
    /// <summary>
    /// Represents a request to download an item(s) in the Shared Space.
    /// <br/><br/>
    /// <b>Target API</b>: SYNO.FotoTeam.Download
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
    public FotoTeamDownloadRequest(int version, string method, string synoToken, IReadOnlyList<int> unitId)
        : base(SynologyApis.FotoTeamDownload, version, method)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(synoToken, nameof(synoToken));

        SynoToken = synoToken;
        UnitId = unitId;
    }
}