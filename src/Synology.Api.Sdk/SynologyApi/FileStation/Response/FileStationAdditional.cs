using System.Text.Json.Serialization;

namespace Synology.Api.Sdk.SynologyApi.FileStation.Response;

public sealed class FileStationAdditional
{
    public FileStationItemOwner? Owner { get; init; }
    public FileStationItemTime? Time { get; init; }
    public string Type { get; init; } = string.Empty;
    
    [JsonPropertyName("real_path")]
    public string RealPath { get; init; } = string.Empty;
    
    [JsonPropertyName("mount_point_type")]
    public string MountPointType { get; init; } = string.Empty;
    
    [JsonPropertyName("perm")]
    public FileStationItemPermissions? Permissions { get; init; }
}