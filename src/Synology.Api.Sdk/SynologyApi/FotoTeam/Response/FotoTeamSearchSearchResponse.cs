using Synology.Api.Sdk.SynologyApi.Shared.Response;

namespace Synology.Api.Sdk.SynologyApi.FotoTeam.Response;

public sealed class FotoTeamSearchSearchResponse : ResponseBase
{
    public FotoTeamSearchSearchData Data { get; init; } = new();
}