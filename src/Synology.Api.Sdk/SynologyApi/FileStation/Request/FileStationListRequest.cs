using System.Text.Json.Serialization;
using Synology.Api.Sdk.Constants;
using Synology.Api.Sdk.SynologyApi.Shared.Request;

namespace Synology.Api.Sdk.SynologyApi.FileStation.Request;

public sealed class FileStationListRequest : RequestBase
{
    [JsonPropertyName("SynoToken")]
    public string SynoToken { get; }

    [JsonPropertyName("offset")]
    public int? Offset { get; }
    
    [JsonPropertyName("limit")]
    public int? Limit { get; }
    
    [JsonPropertyName("additional")]
    public IReadOnlyList<string>? Additional { get; }
    
    [JsonPropertyName("sort_by")]
    public string? SortBy { get; }
    
    [JsonPropertyName("sort_direction")]
    public string? SortDirection { get; }
    
    [JsonPropertyName("onlywritable")]
    public bool? OnlyWritable { get; }

    [JsonPropertyName("goto_path")]
    public string? GoToPath { get; }
    
    [JsonPropertyName("folder_path")]
    public string? FolderPath { get; }
    
    [JsonPropertyName("path")]
    public string? FilePath { get; }
    
    /// <summary>
    /// Represents a request to retrieve a list of files and folders in a directory.
    /// <br/><br/>
    /// <b>Target API</b>: SYNO.FileStation.List
    /// </summary>
    /// <exception cref="ArgumentException">
    /// Thrown if the <paramref name="version"/> parameter is zero or negative.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown if the <paramref name="method"/> parameter is <c>null</c> or white space.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown if the <paramref name="synoToken"/> parameter is <c>null</c> or white space.
    /// </exception>
    public FileStationListRequest(int version, string method, string synoToken, int? offset = null, 
        int? limit = null, IReadOnlyList<string>? additional = null, string? sortBy = null, 
        string? sortDirection = null, bool? onlyWritable = null, string? gotoPath = null, string? folderPath = null,
        string? path = null)
        : base(SynologyApis.FileStationList, version, method)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(synoToken, nameof(synoToken));

        SynoToken = synoToken;
        Offset = offset;
        Limit = limit;
        Additional = additional;
        SortBy = sortBy;
        SortDirection = sortDirection;
        OnlyWritable = onlyWritable;
        GoToPath = gotoPath;
        FolderPath = folderPath;
        FilePath = path;
    }
}