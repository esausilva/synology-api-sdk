using Synology.Api.Sdk.SynologyApi.Shared.Response;

public sealed class FotoTeamBrowseFolderResponse : ResponseBase
{
    public FotoTeamBrowseFolderData Data { get; set; } = new();
}