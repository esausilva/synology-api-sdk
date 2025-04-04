using System.Text.Json.Serialization;
using Synology.Api.Sdk.SynologyApi.Shared.Request;

namespace Synology.Api.Sdk.SynologyApi.Auth.Request;

public sealed class LogoutRequest : RequestBase
{
    [JsonPropertyName("_sid")]
    public string Sid { get; }

    public LogoutRequest(string api, string method, int version, string sid) : base(api, version, method)
    {
        Sid = sid;
    }
}