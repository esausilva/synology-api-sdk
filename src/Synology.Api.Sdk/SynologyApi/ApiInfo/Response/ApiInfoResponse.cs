using System.Text.Json.Serialization;
using Synology.Api.Sdk.SynologyApi.Shared.Response;

namespace Synology.Api.Sdk.SynologyApi.ApiInfo.Response;

public sealed class ApiInfoResponse
{
    public ApiData Data { get; init; } = new();
    public bool Success { get; init; }
    public ErrorResponse? Error { get; init; }
}

public sealed class ApiData
{
    [JsonPropertyName("SYNO.API.Auth")]
    public ApiDetails SynoApiAuth { get; init; } = new();

    [JsonPropertyName("SYNO.FileStation.List")]
    public ApiDetails SynoFileStationList { get; init; } = new();
    
    [JsonPropertyName("SYNO.FileStation.Download")]
    public ApiDetails SynoFileStationDownload { get; init; } = new();
    
    [JsonPropertyName("SYNO.FileStation.Search")]
    public ApiDetails SynoFileStationSearch { get; init; } = new();
    
    [JsonPropertyName("SYNO.Foto.Browse.Album")]
    public ApiDetails SynoFotoBrowseAlbum { get; init; } = new();
    
    [JsonPropertyName("SYNO.FotoTeam.Browse.Folder")]
    public ApiDetails SynoFotoTeamBrowseFolder { get; init; } = new();
    
    [JsonPropertyName("SYNO.FotoTeam.Browse.Item")]
    public ApiDetails SynoFotoTeamBrowseItem { get; init; } = new();
    
    [JsonPropertyName("SYNO.FotoTeam.Browse.RecentlyAdded")]
    public ApiDetails SynoFotoTeamBrowseRecentlyAdded { get; init; } = new();
    
    [JsonPropertyName("SYNO.FotoTeam.Download")]
    public ApiDetails SynoFotoTeamDownload { get; init; } = new();
    
    [JsonPropertyName("SYNO.FotoTeam.Thumbnail")]
    public ApiDetails SynoFotoTeamThumbnail { get; init; } = new();
    
    [JsonPropertyName("SYNO.FotoTeam.Search.Search")]
    public ApiDetails SynoFotoTeamSearchSearch { get; init; } = new();
    
    [JsonPropertyName("SYNO.FotoTeam.Browse.Timeline")]
    public ApiDetails SynoFotoTeamBrowseTimeline { get; init; } = new();
}

public sealed class ApiDetails
{
    public int MaxVersion { get; init; }
    public int MinVersion { get; init; }
    public string Path { get; init; } = string.Empty;
    public string? RequestFormat { get; init; }
}
