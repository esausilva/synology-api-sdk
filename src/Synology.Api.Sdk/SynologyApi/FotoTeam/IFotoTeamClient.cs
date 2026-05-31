using Synology.Api.Sdk.SynologyApi.FotoTeam.Request;
using Synology.Api.Sdk.SynologyApi.FotoTeam.Response;
using Synology.Api.Sdk.SynologyApi.Shared.Response;

namespace Synology.Api.Sdk.SynologyApi.FotoTeam;

public interface IFotoTeamClient
{
    Task<FotoTeamBrowseFolderResponse> BrowseFolderAsync(FotoTeamBrowseFolderRequest request, CancellationToken cancellationToken = default);
    Task<FotoTeamBrowseItemResponse> BrowseItemAsync(FotoTeamBrowseItemRequest request, CancellationToken cancellationToken = default);
    Task<FotoTeamBrowseRecentlyAddedResponse> BrowseRecentlyAddedAsync(FotoTeamBrowseRecentlyAddedRequest request, CancellationToken cancellationToken = default);
    Task<FotoTeamBrowseTimelineResponse> BrowseTimelineAsync(FotoTeamBrowseTimelineRequest request, CancellationToken cancellationToken = default);
    Task<FotoTeamSearchSearchResponse> SearchAsync(FotoTeamSearchSearchRequest request, CancellationToken cancellationToken = default);
    
    Task<RawResponse> DownloadAsync(FotoTeamDownloadRequest request, CancellationToken cancellationToken = default);
    Task<RawResponse> ThumbnailAsync(FotoTeamThumbnailRequest request, CancellationToken cancellationToken = default);
}
