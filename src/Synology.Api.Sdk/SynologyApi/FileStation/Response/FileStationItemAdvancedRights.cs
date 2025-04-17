using System.Text.Json.Serialization;

namespace Synology.Api.Sdk.SynologyApi.FileStation.Response;

public sealed class FileStationItemAdvancedRights
{
    [JsonPropertyName("disable_download")]
    public bool DisableDownload { get; init; }
    
    [JsonPropertyName("disable_list")]
    public bool DisableList { get; init; }
    
    [JsonPropertyName("disable_modify")]
    public bool DisableModify { get; init; }
}