using Synology.Api.Sdk.SynologyApi.Shared.Response;

namespace Synology.Api.Sdk.SynologyApi.Auth.Response;

public sealed class LogoutResponse : ResponseBase
{
    public bool Success { get; init; }
}