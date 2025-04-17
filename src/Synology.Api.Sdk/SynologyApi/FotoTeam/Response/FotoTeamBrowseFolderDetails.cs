using System.Text.Json.Serialization;

namespace Synology.Api.Sdk.SynologyApi.FotoTeam.Response;

public sealed class FotoTeamBrowseFolderDetails
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public int Parent { get; init; }
    public string Passphrase { get; init; } = string.Empty;
    public bool Shared { get; init; }

    [JsonPropertyName("owner_user_id")]
    public int OwnerUserId { get; init; }

    [JsonPropertyName("sort_by")]
    public string SortBy { get; init; } = string.Empty;
    
    [JsonPropertyName("sort_direction")]
    public string SortDirection { get; init; } = string.Empty;
}