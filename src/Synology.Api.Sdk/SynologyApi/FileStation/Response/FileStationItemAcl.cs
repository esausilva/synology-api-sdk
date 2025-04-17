using System.Text.Json.Serialization;

namespace Synology.Api.Sdk.SynologyApi.FileStation.Response;

public sealed class FileStationItemAcl
{
    [JsonPropertyName("append")]
    public bool CanAppend { get; init; }
    
    [JsonPropertyName("del")]
    public bool CanDelete { get; init; }
    
    [JsonPropertyName("exec")]
    public bool CanExecute { get; init; }
    
    [JsonPropertyName("read")]
    public bool CanRead { get; init; }
    
    [JsonPropertyName("write")]
    public bool CanWrite { get; init; }
}