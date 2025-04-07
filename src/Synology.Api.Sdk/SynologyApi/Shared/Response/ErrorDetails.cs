namespace Synology.Api.Sdk.SynologyApi.Shared.Response;

public sealed class ErrorDetails
{
    public string Name { get; init; } = string.Empty;
    public string Reason { get; init; } = string.Empty;
}