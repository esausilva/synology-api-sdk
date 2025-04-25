using System.Text.Json.Serialization;

namespace Synology.Api.Sdk.SynologyApi.FileStation.Response;

public sealed class FileStationSearchStartData
{
    [JsonPropertyName("has_not_index_share")]
    public bool HasNotIndexShare { get; init; }

    [JsonPropertyName("taskid")]
    public string TaskId { get; init; } = string.Empty;
}