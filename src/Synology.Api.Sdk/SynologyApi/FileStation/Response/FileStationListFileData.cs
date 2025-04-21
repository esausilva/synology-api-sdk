namespace Synology.Api.Sdk.SynologyApi.FileStation.Response;

public sealed class FileStationListFileData
{
    public int Offset { get; init; }
    public int Total { get; init; }
    public IReadOnlyList<FileStationItemWithChildren> Files { get; init; } = [];
}