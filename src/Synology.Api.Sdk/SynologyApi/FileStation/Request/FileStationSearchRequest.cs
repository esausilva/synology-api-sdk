using System.Text.Json.Serialization;
using Synology.Api.Sdk.Constants;
using Synology.Api.Sdk.SynologyApi.Shared.Request;
using ApiMethods = Synology.Api.Sdk.Constants.SynologyApiMethods;

namespace Synology.Api.Sdk.SynologyApi.FileStation.Request;

public sealed class FileStationSearchRequest : RequestBase
{
    [JsonPropertyName("SynoToken")]
    public string SynoToken { get; }

    [JsonPropertyName("folder_path")]
    public IReadOnlyList<string>? FolderPaths { get; }

    [JsonPropertyName("filetype")]
    public string? FileType { get; }
    
    [JsonPropertyName("pattern")]
    public string? Pattern { get; }
    
    [JsonPropertyName("extension")]
    public string? Extension { get; }

    [JsonPropertyName("recursive")]
    public bool? Recursive { get; }

    [JsonPropertyName("taskid")]
    public string? TaskId { get; }
    
    [JsonPropertyName("offset")]
    public int? Offset { get; }
    
    [JsonPropertyName("limit")]
    public int? Limit { get; }
    
    [JsonPropertyName("additional")]
    public IReadOnlyList<string>? Additional { get; }

    /// <summary>
    /// Represents a request to retrieve a list of files and folders in a directory based on a search criteria.
    /// <br/><br/>
    /// <b>Target API</b>: SYNO.FileStation.Search
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
    /// <exception cref="ArgumentException">
    /// Thrown if the <paramref name="folderPaths"/> parameter is <c>null</c> or empty when
    /// <paramref name="method"/> is <see cref="FileStationSearch.Start"/>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Conditionally thrown if the <paramref name="taskId"/> parameter is <c>null</c> or white space when
    /// <paramref name="method"/> is <see cref="FileStationSearch.Stop"/> or <see cref="FileStationSearch.Clean"/>.
    /// </exception>
    public FileStationSearchRequest(int version, string method, string synoToken, IReadOnlyList<string>? folderPaths = null,
        string? fileType = null, string? pattern = null, string? extension = null, bool? recursive = null,
        string? taskId = null, int? offset = null, int? limit = null, IReadOnlyList<string>? additional = null)
        : base(SynologyApis.FileStation.Search, version, method)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(synoToken, nameof(synoToken));
        
        if (ShouldRequireFolderPaths()) 
            throw new ArgumentException("The path parameter cannot be null or empty.", nameof(folderPaths));
        
        if (ShouldRequireTaskId())
            ArgumentException.ThrowIfNullOrWhiteSpace(taskId, nameof(taskId));

        SynoToken = synoToken;
        FolderPaths = folderPaths;
        FileType = fileType;
        Pattern = pattern;
        Extension = extension;
        Recursive = recursive;
        TaskId = taskId;
        Offset = offset;
        Limit = limit;
        Additional = additional;

        return;

        bool ShouldRequireFolderPaths()
        {
            return method.Equals(ApiMethods.FileStation.Search_Start, StringComparison.InvariantCultureIgnoreCase) &&
                   (folderPaths is null || folderPaths.Count == 0);
        }

        bool ShouldRequireTaskId()
        {
            return (method.Equals(ApiMethods.FileStation.Search_Stop, StringComparison.InvariantCultureIgnoreCase) || 
                    method.Equals(ApiMethods.FileStation.Search_Clean, StringComparison.InvariantCultureIgnoreCase)) 
                   && string.IsNullOrWhiteSpace(taskId);
        }
    }
}