namespace Synology.Api.Sdk.SynologyApi.FotoTeam.Response;

public sealed class FotoTeamBrowseTimelineData
{
    public IReadOnlyList<FotoTeamBrowseTimelineSection> Section { get; init; } = [];
}