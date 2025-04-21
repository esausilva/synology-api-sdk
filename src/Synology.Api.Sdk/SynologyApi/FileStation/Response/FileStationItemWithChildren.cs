namespace Synology.Api.Sdk.SynologyApi.FileStation.Response;

public sealed class FileStationItemWithChildren : FileStationItem
{
    public FileStationItemChildren? Children { get; init; }
}