using System.Text.Json.Serialization;
using Synology.Api.Sdk.SynologyApi.Shared.Response;

namespace Synology.Api.Sdk.SynologyApi.ApiInfo.Response;

public sealed class ApiInfoResponse : ResponseBase
{
    public ApiInfoData Data { get; init; } = new();
    public bool Success { get; init; }
}

public sealed class ApiInfoData
{
    [JsonPropertyName("SYNO.API.Auth")]
    public ApiInfoDetails SynoApiAuth { get; init; } = new();

    [JsonPropertyName("SYNO.FileStation.List")]
    public ApiInfoDetails SynoFileStationList { get; init; } = new();
    
    [JsonPropertyName("SYNO.FileStation.Download")]
    public ApiInfoDetails SynoFileStationDownload { get; init; } = new();
    
    [JsonPropertyName("SYNO.FileStation.Search")]
    public ApiInfoDetails SynoFileStationSearch { get; init; } = new();
    
    [JsonPropertyName("SYNO.Foto.Browse.Album")]
    public ApiInfoDetails SynoFotoBrowseAlbum { get; init; } = new();
    
    [JsonPropertyName("SYNO.FotoTeam.Browse.Folder")]
    public ApiInfoDetails SynoFotoTeamBrowseFolder { get; init; } = new();
    
    [JsonPropertyName("SYNO.FotoTeam.Browse.Item")]
    public ApiInfoDetails SynoFotoTeamBrowseItem { get; init; } = new();
    
    [JsonPropertyName("SYNO.FotoTeam.Browse.RecentlyAdded")]
    public ApiInfoDetails SynoFotoTeamBrowseRecentlyAdded { get; init; } = new();
    
    [JsonPropertyName("SYNO.FotoTeam.Download")]
    public ApiInfoDetails SynoFotoTeamDownload { get; init; } = new();
    
    [JsonPropertyName("SYNO.FotoTeam.Thumbnail")]
    public ApiInfoDetails SynoFotoTeamThumbnail { get; init; } = new();
    
    [JsonPropertyName("SYNO.FotoTeam.Search.Search")]
    public ApiInfoDetails SynoFotoTeamSearchSearch { get; init; } = new();
    
    [JsonPropertyName("SYNO.FotoTeam.Browse.Timeline")]
    public ApiInfoDetails SynoFotoTeamBrowseTimeline { get; init; } = new();
}

public sealed class ApiInfoDetails
{
    public int MaxVersion { get; init; }
    public int MinVersion { get; init; }
    public string Path { get; init; } = string.Empty;
    public string? RequestFormat { get; init; }
}
