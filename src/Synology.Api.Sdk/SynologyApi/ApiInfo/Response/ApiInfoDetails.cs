namespace Synology.Api.Sdk.SynologyApi.ApiInfo.Response;

public sealed class ApiInfoDetails
{
    public int MaxVersion { get; init; }
    public int MinVersion { get; init; }
    public string Path { get; init; } = string.Empty;
    public string? RequestFormat { get; init; }
}