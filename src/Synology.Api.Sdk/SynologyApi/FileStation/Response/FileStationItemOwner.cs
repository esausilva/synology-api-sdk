using System.Text.Json.Serialization;

namespace Synology.Api.Sdk.SynologyApi.FileStation.Response;

public sealed class FileStationItemOwner
{
    public string User { get; init; } = string.Empty;
    public string Group { get; init; } = string.Empty;
    
    [JsonPropertyName("uid")]
    public int UserId { get; init; }
    
    [JsonPropertyName("gid")]
    public int GroupId { get; init; }
}