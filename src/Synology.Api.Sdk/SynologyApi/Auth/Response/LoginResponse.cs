using System.Text.Json.Serialization;
using Synology.Api.Sdk.SynologyApi.Shared.Response;

namespace Synology.Api.Sdk.SynologyApi.Auth.Response;

public sealed class LoginResponse
{
    public DataDetail Data { get; init; } = new();
    public bool Success { get; init; }
    public ErrorResponse? Error { get; init; }
}

public sealed class DataDetail
{
    public string Did { get; init; } = string.Empty;
    public string Sid { get; init; } = string.Empty;
    public string? SynoToken { get; init; }

    [JsonPropertyName("is_portal_port")]
    public bool IsPortalPort { get; init; }
}