using Synology.Api.Sdk.SynologyApi.Shared.Response;

namespace Synology.Api.Sdk.SynologyApi.FotoTeam.Response;

public sealed class FotoTeamBrowseItemResponse : ResponseBase
{
    public FotoTeamItemData Data { get; init; } = new();
}