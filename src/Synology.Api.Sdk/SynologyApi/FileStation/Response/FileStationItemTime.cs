using System.Text.Json.Serialization;

namespace Synology.Api.Sdk.SynologyApi.FileStation.Response;

public sealed class FileStationItemTime
{
    [JsonPropertyName("atime")]
    public long AccessTime { get; init; }
    
    [JsonPropertyName("crtime")]
    public long CreationTime { get; init; }
    
    [JsonPropertyName("ctime")]
    public long ChangeTime { get; init; }
    
    [JsonPropertyName("mtime")]
    public long ModificationTime { get; init; }
}