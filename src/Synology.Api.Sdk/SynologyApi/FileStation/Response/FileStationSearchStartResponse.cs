using Synology.Api.Sdk.SynologyApi.Shared.Response;

namespace Synology.Api.Sdk.SynologyApi.FileStation.Response;

public sealed class FileStationSearchStartResponse : ResponseBase
{
    public FileStationSearchStartData Data { get; init; } = new();
}