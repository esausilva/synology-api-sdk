using Synology.Api.Sdk.SynologyApi.Shared.Response;

namespace Synology.Api.Sdk.SynologyApi.Auth.Response;

public sealed class LoginResponse : ResponseBase
{
    public LoginData Data { get; init; } = new();
}