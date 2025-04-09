using System.Text.Json.Serialization;

namespace Synology.Api.Sdk.SynologyApi.FotoTeam.Response;

public sealed class FotoTeamBrowseTimelineItem
{
    public int Day { get; init; }
    public int Month { get; init; }
    public int Year { get; init; }

    [JsonPropertyName("item_count")]
    public int ItemCount { get; init; }
}