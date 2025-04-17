using System.ComponentModel.DataAnnotations;

namespace Synology.Api.Sdk.Constants;

public enum ApiInfo
{
    [Display(Name = "query")]
    Query,
}

#region Authentication

public enum ApiAuth
{
    [Display(Name = "login")]
    Login,
    
    [Display(Name = "logout")]
    Logout,
}

#endregion

#region FileStation

public enum FileStationList
{
    [Display(Name = "list_share")]
    ListShare,
}

#endregion

#region Foto

public enum FotoBrowseAlbum
{
    [Display(Name = "list")]
    List,
}

#endregion

#region FotoTeam

public enum FotoTeamBrowseFolder
{
    [Display(Name = "list_parents")]
    ListParents,
    
    [Display(Name = "list")]
    List,
}

public enum FotoTeamBrowseItem
{
    [Display(Name = "list")]
    List,
}

public enum FotoTeamBrowseRecentlyAdded
{
    [Display(Name = "list")]
    List,
}

public enum FotoTeamBrowseTimeline
{
    [Display(Name = "get")]
    Get,
}

public enum FotoTeamDownload
{
    [Display(Name = "download")]
    Download,
}

public enum FotoTeamThumbnail
{
    [Display(Name = "get")]
    Get,
}

public enum FotoTeamSearchSearch
{
    [Display(Name = "count_item")]
    CountItem,
}

#endregion