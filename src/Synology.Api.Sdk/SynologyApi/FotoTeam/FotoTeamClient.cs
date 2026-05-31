using Synology.Api.Sdk.SynologyApi.FotoTeam.Request;
using Synology.Api.Sdk.SynologyApi.FotoTeam.Response;
using Synology.Api.Sdk.SynologyApi.Shared.Response;

namespace Synology.Api.Sdk.SynologyApi.FotoTeam;

internal sealed class FotoTeamClient(ISynologyApiRequestBuilder requestBuilder, ISynologyApiService apiService) : IFotoTeamClient
{
    public Task<FotoTeamBrowseFolderResponse> BrowseFolderAsync(FotoTeamBrowseFolderRequest request, CancellationToken cancellationToken = default)
    {
        var url = requestBuilder.BuildUrl(request);
        return apiService.GetAsync<FotoTeamBrowseFolderResponse>(url, cancellationToken);
    }

    public Task<FotoTeamBrowseItemResponse> BrowseItemAsync(FotoTeamBrowseItemRequest request, CancellationToken cancellationToken = default)
    {
        var url = requestBuilder.BuildUrl(request);
        return apiService.GetAsync<FotoTeamBrowseItemResponse>(url, cancellationToken);
    }

    public Task<FotoTeamBrowseRecentlyAddedResponse> BrowseRecentlyAddedAsync(FotoTeamBrowseRecentlyAddedRequest request, CancellationToken cancellationToken = default)
    {
        var url = requestBuilder.BuildUrl(request);
        return apiService.GetAsync<FotoTeamBrowseRecentlyAddedResponse>(url, cancellationToken);
    }

    public Task<FotoTeamBrowseTimelineResponse> BrowseTimelineAsync(FotoTeamBrowseTimelineRequest request, CancellationToken cancellationToken = default)
    {
        var url = requestBuilder.BuildUrl(request);
        return apiService.GetAsync<FotoTeamBrowseTimelineResponse>(url, cancellationToken);
    }

    public Task<FotoTeamSearchSearchResponse> SearchAsync(FotoTeamSearchSearchRequest request, CancellationToken cancellationToken = default)
    {
        var url = requestBuilder.BuildUrl(request);
        return apiService.GetAsync<FotoTeamSearchSearchResponse>(url, cancellationToken);
    }

    public Task<RawResponse> DownloadAsync(FotoTeamDownloadRequest request, CancellationToken cancellationToken = default)
    {
        var url = requestBuilder.BuildUrl(request);
        return apiService.GetRawResponseAsync(url, cancellationToken);
    }

    public Task<RawResponse> ThumbnailAsync(FotoTeamThumbnailRequest request, CancellationToken cancellationToken = default)
    {
        var url = requestBuilder.BuildUrl(request);
        return apiService.GetRawResponseAsync(url, cancellationToken);
    }
}
