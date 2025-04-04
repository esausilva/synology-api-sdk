using Synology.Api.Sdk.SynologyApi.Shared.Request;

namespace Synology.Api.Sdk.SynologyApi.ApiInfo.Request;

public class ApiInfoRequest : RequestBase
{
    public ApiInfoRequest(string api, int version, string method) : base(api, version, method)
    {
    }
}