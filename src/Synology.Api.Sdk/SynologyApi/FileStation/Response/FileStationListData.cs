namespace Synology.Api.Sdk.SynologyApi.FileStation.Response;

public sealed class FileStationListData
{
    public int Offset { get; init; }
    public int Total { get; init; }
    public IReadOnlyList<FileStationItem> Shares { get; init; } = [];
}