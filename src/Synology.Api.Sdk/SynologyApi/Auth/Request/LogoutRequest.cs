using System.Text.Json.Serialization;
using Synology.Api.Sdk.Constants;
using Synology.Api.Sdk.SynologyApi.Shared.Request;

namespace Synology.Api.Sdk.SynologyApi.Auth.Request;

public sealed class LogoutRequest : RequestBase
{
    [JsonPropertyName("_sid")]
    public string Sid { get; }

    /// <summary>
    /// Represents a request to log out to Synology NAS.
    /// <br/><br/>
    /// <b>Target API</b>: SYNO.API.Auth
    /// </summary>
    /// <exception cref="ArgumentException">
    /// Thrown if the <paramref name="api"/> parameter is <c>null</c> or white space.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown if the <paramref name="version"/> parameter is zero or negative.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown if the <paramref name="method"/> parameter is <c>null</c> or white space.
    /// </exception>
    public LogoutRequest(string method, int version, string sid = "") : base(SynologyApis.ApiAuth, version, method)
    {
        Sid = sid;
    }
}