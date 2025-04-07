using System.Text.Json.Serialization;

public sealed class FotoBrowseAlbumDetails
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Passphrase { get; init; } = string.Empty;
    public bool Shared { get; init; }
    public string Type { get; init; } = string.Empty;
    public int Version { get; init; }

    [JsonPropertyName("create_time")]
    public long CreateTime { get; init; }

    [JsonPropertyName("end_time")]
    public long EndTime { get; init; }

    [JsonPropertyName("freeze_album")]
    public bool FreezeAlbum { get; init; }

    [JsonPropertyName("item_count")]
    public int ItemCount { get; init; }

    [JsonPropertyName("owner_user_id")]
    public int OwnerUserId { get; init; }

    [JsonPropertyName("sort_by")]
    public string SortBy { get; init; } = string.Empty;

    [JsonPropertyName("sort_direction")]
    public string SortDirection { get; init; } = string.Empty;

    [JsonPropertyName("start_time")]
    public long StartTime { get; init; }

    [JsonPropertyName("temporary_shared")]
    public bool TemporaryShared { get; init; }
}