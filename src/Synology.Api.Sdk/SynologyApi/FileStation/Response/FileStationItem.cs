using System.Text.Json.Serialization;

namespace Synology.Api.Sdk.SynologyApi.FileStation.Response;

public sealed class FileStationItem
{
    public string Name { get; init; } = string.Empty;
    public string Path { get; init; } = string.Empty;
    public FileStationAdditional? Additional { get; init; }
    
    [JsonPropertyName("isdir")]
    public bool IsDirectory { get; init; }
}