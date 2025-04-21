using Synology.Api.Sdk.SynologyApi.Shared.Response;

namespace Synology.Api.Sdk.SynologyApi.FileStation.Response;

public sealed class FileStationListShareResponse : ResponseBase
{
    public FileStationListShareData Data { get; init; } = new();
}