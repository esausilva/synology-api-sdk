using System.Text.Json.Serialization;

namespace Synology.Api.Sdk.SynologyApi.Auth.Response;

public sealed class LoginData
{
    public string Sid { get; init; } = string.Empty;

    public string Account { get; init; } = string.Empty;

    public string? SynoToken { get; init; }

    [JsonPropertyName("device_id")]
    public string DeviceId { get; init; } = string.Empty;

    [JsonPropertyName("ik_message")]
    public string IkMessage { get; init; } = string.Empty;

    [JsonPropertyName("is_portal_port")]
    public bool IsPortalPort { get; init; }
}