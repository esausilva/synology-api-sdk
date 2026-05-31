using Synology.Api.Sdk.SynologyApi.ApiInfo.Request;
using Synology.Api.Sdk.SynologyApi.ApiInfo.Response;

namespace Synology.Api.Sdk.SynologyApi.ApiInfo;

public interface IApiInfoClient
{
    Task<ApiInfoResponse> QueryAsync(ApiInfoRequest request, CancellationToken cancellationToken = default);
}
