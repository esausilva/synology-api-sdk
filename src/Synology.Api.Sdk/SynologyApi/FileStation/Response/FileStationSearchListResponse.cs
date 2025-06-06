using Synology.Api.Sdk.SynologyApi.Shared.Response;

namespace Synology.Api.Sdk.SynologyApi.FileStation.Response;

public sealed class FileStationSearchListResponse : ResponseBase
{
    public FileStationSearchListData Data { get; init; } = new();
}