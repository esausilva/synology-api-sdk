namespace Synology.Api.Sdk.SynologyApi.Shared.Response;

public sealed class ErrorResponse
{
    public int Code { get; init; }
    public ErrorDetails Errors { get; init; } = new();
}