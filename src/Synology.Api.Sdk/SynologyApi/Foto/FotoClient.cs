using Synology.Api.Sdk.SynologyApi.Foto.Request;
using Synology.Api.Sdk.SynologyApi.Foto.Response;

namespace Synology.Api.Sdk.SynologyApi.Foto;

internal sealed class FotoClient(ISynologyApiRequestBuilder requestBuilder, ISynologyApiService apiService) : IFotoClient
{
    public Task<FotoBrowseAlbumResponse> BrowseAlbumAsync(FotoBrowseAlbumRequest request, CancellationToken cancellationToken = default)
    {
        var url = requestBuilder.BuildUrl(request);
        return apiService.GetAsync<FotoBrowseAlbumResponse>(url, cancellationToken);
    }
}
