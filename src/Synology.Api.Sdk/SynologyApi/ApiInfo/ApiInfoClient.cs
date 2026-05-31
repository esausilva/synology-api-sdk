using Synology.Api.Sdk.SynologyApi.ApiInfo.Request;
using Synology.Api.Sdk.SynologyApi.ApiInfo.Response;

namespace Synology.Api.Sdk.SynologyApi.ApiInfo;

internal sealed class ApiInfoClient(ISynologyApiRequestBuilder requestBuilder, ISynologyApiService apiService) : IApiInfoClient
{
    public Task<ApiInfoResponse> QueryAsync(ApiInfoRequest request, CancellationToken cancellationToken = default)
    {
        var url = requestBuilder.BuildUrl(request);
        return apiService.GetAsync<ApiInfoResponse>(url, cancellationToken);
    }
}
