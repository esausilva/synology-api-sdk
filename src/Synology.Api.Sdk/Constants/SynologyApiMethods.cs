namespace Synology.Api.Sdk.Constants;

public static class SynologyApiMethods
{
    public static class Api
    {
        public const string Info_Query = "query";
        public const string Auth_Login = "login";
        public const string Auth_Logout = "logout";
    }
    
    public static class FileStation
    {
        #region List

        public const string List_ListShare = "list_share";
        public const string List_List = "list";
        public const string List_GetInfo = "getinfo";

        #endregion

        #region Search

        public const string Search_Start = "start";
        public const string Search_List = "list";
        public const string Search_Stop = "stop";
        public const string Search_Clean = "clean";

        #endregion

        #region Download

        public const string Download_Download = "download";

        #endregion
    }
    
    public static class Foto
    {
        #region BrowseAlbum

        public const string BrowseAlbum_List = "list";

        #endregion
    }
    
    public static class FotoTeam
    {
        #region BrowseFolder
        
        public const string BrowseFolder_ListParents = "list_parents";
        public const string BrowseFolder_List = "list";
        
        #endregion
        
        #region BrowseItem
        
        public const string BrowseItem_List = "list";
        
        #endregion
        
        #region BrowseRecentlyAdded
        
        public const string BrowseRecentlyAdded_List = "list";
        
        #endregion
        
        #region BrowseTimeline
        
        public const string BrowseTimeline_Get = "get";
        
        #endregion
        
        #region Download
        
        public const string Download_Download = "download";
        
        #endregion
        
        #region Thumbnail
        
        public const string Thumbnail_Get = "get";
        
        #endregion
        
        #region SearchSearch
        
        public const string SearchSearch_CountItem = "count_item";
        
        #endregion
    }
}