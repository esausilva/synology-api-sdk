using Synology.Api.Sdk.SynologyApi.Shared.Response;

namespace Synology.Api.Sdk.SynologyApi.FotoTeam.Response;

public sealed class FotoTeamBrowseFolderResponse : ResponseBase
{
    public FotoTeamBrowseFolderData Data { get; set; } = new();
}