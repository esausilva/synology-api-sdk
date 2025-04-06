using Synology.Api.Sdk.SynologyApi.Shared.Response;

namespace Synology.Api.Sdk.SynologyApi.ApiInfo.Response;

public sealed class ApiInfoResponse : ResponseBase
{
    public ApiInfoData Data { get; init; } = new();
}