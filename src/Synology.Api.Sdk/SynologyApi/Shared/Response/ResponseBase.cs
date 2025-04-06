using System.Net;

namespace Synology.Api.Sdk.SynologyApi.Shared.Response;

public class ResponseBase
{
    public HttpStatusCode StatusCode { get; init; }
    public ErrorResponse? Error { get; init; }
}