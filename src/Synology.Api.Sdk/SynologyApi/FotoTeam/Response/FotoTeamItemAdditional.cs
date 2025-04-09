namespace Synology.Api.Sdk.SynologyApi.FotoTeam.Response;

public sealed class FotoTeamItemAdditional
{
    public ThumbnailDetails? Thumbnail { get; init; }
    public string Folder { get; init; } = string.Empty;
}