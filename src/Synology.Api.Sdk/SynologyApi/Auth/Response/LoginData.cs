using System.Text.Json.Serialization;

namespace Synology.Api.Sdk.SynologyApi.Auth.Response;

public sealed class LoginData
{
    public string Did { get; init; } = string.Empty;
    public string Sid { get; init; } = string.Empty;
    public string? SynoToken { get; init; }

    [JsonPropertyName("is_portal_port")]
    public bool IsPortalPort { get; init; }
}