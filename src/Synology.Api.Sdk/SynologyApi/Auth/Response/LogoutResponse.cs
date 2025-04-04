using Synology.Api.Sdk.SynologyApi.Shared.Response;

namespace Synology.Api.Sdk.SynologyApi.Auth.Response;

public sealed class LogoutResponse
{
    public bool Success { get; init; }
    public ErrorResponse? Error { get; init; }
}