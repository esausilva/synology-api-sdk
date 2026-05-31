using Synology.Api.Sdk.SynologyApi.Auth.Request;
using Synology.Api.Sdk.SynologyApi.Auth.Response;

namespace Synology.Api.Sdk.SynologyApi.Auth;

internal sealed class AuthClient(ISynologyApiRequestBuilder requestBuilder, ISynologyApiService apiService) : IAuthClient
{
    public Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default)
    {
        var url = requestBuilder.BuildUrl(request);
        return apiService.GetAsync<LoginResponse>(url, cancellationToken);
    }

    public Task<LogoutResponse> LogoutAsync(LogoutRequest request, CancellationToken cancellationToken = default)
    {
        var url = requestBuilder.BuildUrl(request);
        return apiService.GetAsync<LogoutResponse>(url, cancellationToken);
    }
}
