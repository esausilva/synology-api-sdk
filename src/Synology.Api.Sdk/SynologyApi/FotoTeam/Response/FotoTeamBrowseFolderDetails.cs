using System.Text.Json.Serialization;

namespace Synology.Api.Sdk.SynologyApi.FotoTeam.Response;

public sealed class FotoTeamBrowseFolderDetails
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Parent { get; set; }
    public string Passphrase { get; set; } = string.Empty;
    public bool Shared { get; set; }

    [JsonPropertyName("owner_user_id")]
    public int OwnerUserId { get; set; }

    [JsonPropertyName("sort_by")]
    public string SortBy { get; set; } = string.Empty;
    
    [JsonPropertyName("sort_direction")]
    public string SortDirection { get; set; } = string.Empty;
}