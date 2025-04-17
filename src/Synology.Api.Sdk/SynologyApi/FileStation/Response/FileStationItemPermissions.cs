using System.Text.Json.Serialization;

namespace Synology.Api.Sdk.SynologyApi.FileStation.Response;

public sealed class FileStationItemPermissions
{
    public FileStationItemAcl Acl { get; init; } = new();
    public int Posix { get; init; }
    
    [JsonPropertyName("acl_enable")]
    public bool AclEnabled { get; init; }
    
    [JsonPropertyName("adv_right")]
    public FileStationItemAdvancedRights AdvancedRights { get; init; } = new();
    
    [JsonPropertyName("is_acl_mode")]
    public bool IsAclMode { get; init; }
    
    [JsonPropertyName("is_share_readonly")]
    public bool IsShareReadonly { get; init; }
    
    [JsonPropertyName("share_right")]
    public string ShareRight { get; init; } = string.Empty;
}