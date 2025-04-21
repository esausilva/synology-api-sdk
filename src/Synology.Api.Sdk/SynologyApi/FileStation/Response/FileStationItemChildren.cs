namespace Synology.Api.Sdk.SynologyApi.FileStation.Response;

public sealed class FileStationItemChildren
{
    public IReadOnlyList<FileStationItem> Files { get; init; } = [];
}