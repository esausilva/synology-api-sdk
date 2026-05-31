using Synology.Api.Sdk.SynologyApi.Auth.Request;
using Synology.Api.Sdk.SynologyApi.Auth.Response;

namespace Synology.Api.Sdk.SynologyApi.Auth;

public interface IAuthClient
{
    Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default);
    Task<LogoutResponse> LogoutAsync(LogoutRequest request, CancellationToken cancellationToken = default);
}
