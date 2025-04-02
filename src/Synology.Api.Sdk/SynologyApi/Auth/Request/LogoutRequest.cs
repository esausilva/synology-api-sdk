using System.Text.Json.Serialization;

namespace Synology.Api.Sdk.SynologyApi.Auth.Request;

public sealed class LogoutRequest : RequestBase
{
    [JsonPropertyName("_sid")]
    public string Sid { get; }

    public LogoutRequest(string api, string method, int version, string sid) : base(api, version, method)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(sid, nameof(sid));
        
        Sid = sid;
    }
}