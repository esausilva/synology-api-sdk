namespace Synology.Api.Sdk.SynologyApi.FileStation.Response;

public sealed class FileStationSearchListData
{
    public bool Finished { get; init; }
    public int Offset { get; init; }
    public int Total { get; init; }
    public IReadOnlyList<FileStationItem> Files { get; init; } = [];
}