using Synology.Api.Sdk.SynologyApi.Shared.Response;

namespace Synology.Api.Sdk.SynologyApi.FileStation.Response;

public sealed class FileStationListResponse : ResponseBase
{
    public FileStationListData Data { get; init; } = new();
}