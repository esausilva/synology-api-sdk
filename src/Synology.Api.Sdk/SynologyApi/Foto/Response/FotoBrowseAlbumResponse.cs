using Synology.Api.Sdk.SynologyApi.Shared.Response;

namespace Synology.Api.Sdk.SynologyApi.Foto.Response;

public sealed class FotoBrowseAlbumResponse : ResponseBase
{
    public FotoBrowseAlbumData Data { get; init; } = new();
}