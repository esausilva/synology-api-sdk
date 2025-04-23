using System.Text.Json.Serialization;
using Synology.Api.Sdk.Constants;
using Synology.Api.Sdk.SynologyApi.Shared.Request;

namespace Synology.Api.Sdk.SynologyApi.FileStation.Request;

public sealed class FileStationDownloadRequest : RequestBase
{
    [JsonPropertyName("SynoToken")]
    public string SynoToken { get; }

    [JsonPropertyName("path")]
    public IReadOnlyList<string> FilePaths { get; }

    [JsonPropertyName("mode")]
    public string? Mode { get; }

    /// <summary>
    /// Represents a request to retrieve a list of files and folders in a directory.
    /// <br/><br/>
    /// <b>Target API</b>: SYNO.FileStation.Download
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
    /// Thrown if the <paramref name="path"/> parameter is <c>null</c> or white space.
    /// </exception>
    public FileStationDownloadRequest(int version, string method, string synoToken, IReadOnlyList<string> path, 
        string? mode = null)
        : base(SynologyApis.FileStationDownload, version, method)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(synoToken, nameof(synoToken));
        
        if (path is null || path.Count == 0) 
            throw new ArgumentException("The path parameter cannot be null or empty.", nameof(path));

        SynoToken = synoToken;
        FilePaths = path;
        Mode = mode;
    }
}