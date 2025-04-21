using Synology.Api.Sdk.SynologyApi.Shared.Response;

namespace Synology.Api.Sdk.SynologyApi.FileStation.Response;

public sealed class FileStationListFileResponse : ResponseBase
{
    public FileStationListFileData Data { get; init; } = new();
}