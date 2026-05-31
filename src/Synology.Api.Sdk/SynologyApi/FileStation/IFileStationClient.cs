using Synology.Api.Sdk.SynologyApi.FileStation.Request;
using Synology.Api.Sdk.SynologyApi.FileStation.Response;
using Synology.Api.Sdk.SynologyApi.Shared.Response;

namespace Synology.Api.Sdk.SynologyApi.FileStation;

public interface IFileStationClient
{
    Task<FileStationListShareResponse> ListShareAsync(FileStationListRequest request, CancellationToken cancellationToken = default);
    Task<FileStationListFileResponse> ListFileAsync(FileStationListRequest request, CancellationToken cancellationToken = default);
    
    Task<FileStationSearchStartResponse> SearchStartAsync(FileStationSearchRequest request, CancellationToken cancellationToken = default);
    Task<FileStationSearchListResponse> SearchListAsync(FileStationSearchRequest request, CancellationToken cancellationToken = default);
    Task<FileStationSearchStopResponse> SearchStopAsync(FileStationSearchRequest request, CancellationToken cancellationToken = default);
    Task<FileStationSearchCleanResponse> SearchCleanAsync(FileStationSearchRequest request, CancellationToken cancellationToken = default);
    
    Task<RawResponse> DownloadAsync(FileStationDownloadRequest request, CancellationToken cancellationToken = default);
}
