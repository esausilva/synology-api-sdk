namespace Synology.Api.Sdk.SynologyApi.FotoTeam.Response;

public sealed class FotoTeamBrowseTimelineSection
{
    public int Limit { get; init; }
    public IReadOnlyList<FotoTeamBrowseTimelineItem> List { get; init; } = []; 
    public int Offset { get; init; }
}