namespace Synology.Api.Sdk.SynologyApi.FotoTeam.Response;

public sealed class FotoTeamBrowseItemAdditional
{
    public ThumbnailDetails Thumbnail { get; init; } = new();
    public string Folder { get; init; } = string.Empty;
}