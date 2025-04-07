using Synology.Api.Sdk.SynologyApi.Shared.Response;

public sealed class FotoBrowseAlbumResponse : ResponseBase
{
    public FotoBrowseAlbumData Data { get; init; } = new();
}