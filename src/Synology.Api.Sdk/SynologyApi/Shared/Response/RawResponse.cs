using System.Net;

namespace Synology.Api.Sdk.SynologyApi.Shared.Response;

public sealed class RawResponse
{
    public HttpResponseMessage? HttpResponse { get; init; }
    public bool Success { get; init; }
    public HttpStatusCode StatusCode { get; init; }
    public ErrorResponse? Error { get; init; }
}