using System.Text.Json.Serialization;

namespace Synology.Api.Sdk.SynologyApi.FotoTeam.Response;

public sealed class FotoTeamBrowseItemDetails
{
    public int Id { get; init; }
    public string Filename { get; init; } = string.Empty;
    public long Filesize { get; init; }
    public long Time { get; init; }
    public string Type { get; init; } = string.Empty;
    public FotoTeamBrowseItemAdditional? Additional { get; init; }

    [JsonPropertyName("indexed_time")]
    public long IndexedTime { get; init; }

    [JsonPropertyName("owner_user_id")]
    public int OwnerUserId { get; init; }

    [JsonPropertyName("folder_id")]
    public int FolderId { get; init; }
}