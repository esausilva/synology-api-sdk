namespace Synology.Api.Sdk.SynologyApi.Foto.Response;

public sealed class FotoBrowseAlbumData
{
    public IReadOnlyList<FotoBrowseAlbumDetails> List { get; init; } = [];
}