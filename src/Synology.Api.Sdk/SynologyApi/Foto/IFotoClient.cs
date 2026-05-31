using Synology.Api.Sdk.SynologyApi.Foto.Request;
using Synology.Api.Sdk.SynologyApi.Foto.Response;

namespace Synology.Api.Sdk.SynologyApi.Foto;

public interface IFotoClient
{
    Task<FotoBrowseAlbumResponse> BrowseAlbumAsync(FotoBrowseAlbumRequest request, CancellationToken cancellationToken = default);
}
