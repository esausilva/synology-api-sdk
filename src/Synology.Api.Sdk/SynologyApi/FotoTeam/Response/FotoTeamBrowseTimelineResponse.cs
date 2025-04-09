using Synology.Api.Sdk.SynologyApi.Shared.Response;

namespace Synology.Api.Sdk.SynologyApi.FotoTeam.Response;

public sealed class FotoTeamBrowseTimelineResponse : ResponseBase
{
    public FotoTeamBrowseTimelineData Data { get; init; } = new();
}