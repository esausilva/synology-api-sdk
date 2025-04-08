using System.Text.Json.Serialization;

namespace Synology.Api.Sdk.SynologyApi.FotoTeam.Response;

public sealed class ThumbnailDetails
{
    public string M { get; init; } = string.Empty;
    public string Xl { get; init; } = string.Empty;
    public string Preview { get; init; } = string.Empty;
    public string Sm { get; init; } = string.Empty;
    
    [JsonPropertyName("cache_key")]
    public string CacheKey { get; init; } = string.Empty;
    
    [JsonPropertyName("unit_id")]
    public int UnitId { get; init; }
}