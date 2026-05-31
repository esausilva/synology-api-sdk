using Synology.Api.Sdk.SynologyApi.FileStation.Request;
using Synology.Api.Sdk.SynologyApi.FileStation.Response;
using Synology.Api.Sdk.SynologyApi.Shared.Response;

namespace Synology.Api.Sdk.SynologyApi.FileStation;

internal sealed class FileStationClient(ISynologyApiRequestBuilder requestBuilder, ISynologyApiService apiService) : IFileStationClient
{
    public Task<FileStationListShareResponse> ListShareAsync(FileStationListRequest request, CancellationToken cancellationToken = default)
    {
        var url = requestBuilder.BuildUrl(request);
        return apiService.GetAsync<FileStationListShareResponse>(url, cancellationToken);
    }

    public Task<FileStationListFileResponse> ListFileAsync(FileStationListRequest request, CancellationToken cancellationToken = default)
    {
        var url = requestBuilder.BuildUrl(request);
        return apiService.GetAsync<FileStationListFileResponse>(url, cancellationToken);
    }

    public Task<FileStationSearchStartResponse> SearchStartAsync(FileStationSearchRequest request, CancellationToken cancellationToken = default)
    {
        var url = requestBuilder.BuildUrl(request);
        return apiService.GetAsync<FileStationSearchStartResponse>(url, cancellationToken);
    }

    public Task<FileStationSearchListResponse> SearchListAsync(FileStationSearchRequest request, CancellationToken cancellationToken = default)
    {
        var url = requestBuilder.BuildUrl(request);
        return apiService.GetAsync<FileStationSearchListResponse>(url, cancellationToken);
    }

    public Task<FileStationSearchStopResponse> SearchStopAsync(FileStationSearchRequest request, CancellationToken cancellationToken = default)
    {
        var url = requestBuilder.BuildUrl(request);
        return apiService.GetAsync<FileStationSearchStopResponse>(url, cancellationToken);
    }

    public Task<FileStationSearchCleanResponse> SearchCleanAsync(FileStationSearchRequest request, CancellationToken cancellationToken = default)
    {
        var url = requestBuilder.BuildUrl(request);
        return apiService.GetAsync<FileStationSearchCleanResponse>(url, cancellationToken);
    }

    public Task<RawResponse> DownloadAsync(FileStationDownloadRequest request, CancellationToken cancellationToken = default)
    {
        var url = requestBuilder.BuildUrl(request);
        return apiService.GetRawResponseAsync(url, cancellationToken);
    }
}
