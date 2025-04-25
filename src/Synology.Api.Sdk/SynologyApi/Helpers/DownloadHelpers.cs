using System.Text.RegularExpressions;
using Synology.Api.Sdk.SynologyApi.FileStation.Response;

namespace Synology.Api.Sdk.SynologyApi.Helpers;

public static partial class DownloadHelpers
{
    /// <summary>
    /// Downloads an image or ZIP file from the FotoTeam API and saves it to the specified path.
    /// </summary>
    /// <param name="absolutePath">The absolute path where the file should be saved.</param>
    /// <param name="httpResponse">The HTTP response containing the file data to download.</param>
    /// <remarks>
    /// The method extracts the filename from the "Content-Disposition" header if available.
    /// If the filename is not present, it determines the file extension based on the "Content-Type" header
    /// and defaults the filename to "download.[extension]". It chooses between "zip" and "jpg" extensions
    /// based on the content type. If the content type is not recognized, it defaults to "jpg".
    /// </remarks>
    public static async Task DownloadImageOrZipFromFotoApi(string absolutePath, HttpResponseMessage? httpResponse)
    {
        if (httpResponse is null)
            return;
        
        var filename = string.Empty;
        
        if (httpResponse.Content.Headers
            .TryGetValues("Content-Disposition", out var contentDispositionValues))
        {
            var value = contentDispositionValues.FirstOrDefault();
            filename = ExtractFilenameFromHeaderValue(value);
        }

        if (string.IsNullOrWhiteSpace(filename))
        {
            var contentType = string.Empty;
            
            if (httpResponse.Content.Headers.TryGetValues("Content-Type", out var contentTypeValues))
            {
                contentType = contentTypeValues.FirstOrDefault();
            }

            var extension = contentType switch
            {
                "image/jpeg" => "jpg",
                "application/zip" or "application/x-zip-compressed" or "application/zip, application/octet-stream" => "zip",
                _ => "jpg"
            };
            
            filename = $"download.{extension}";
        }
        
        var filePath = Path.Combine(absolutePath, filename);

        await using var stream = await httpResponse.Content.ReadAsStreamAsync()!;
        await using var fileStream = new FileStream(
            filePath, 
            FileMode.Create, 
            FileAccess.Write, 
            FileShare.None, 
            bufferSize: 8192, 
            useAsync: true);
        
        await stream.CopyToAsync(fileStream);
    }

    /// <summary>
    /// Downloads an image or ZIP file from the FileStation API and saves it to the specified path.
    /// </summary>
    /// <param name="absolutePath">The absolute path where the file should be saved.</param>
    /// <param name="fileStationItems">The list of FileStation items to be downloaded.</param>
    /// <param name="httpResponse">The HTTP response containing the file data to download.</param>
    /// <remarks>
    /// If a single file is being downloaded, the filename is extracted from the `Name` property of
    /// the <see cref="FileStationItem"/>.
    /// For multiple files, the data is saved as a ZIP file named "download.zip".
    /// </remarks>
    public static async Task DownloadImageOrZipFromFileStationApi(
        string absolutePath,
        IReadOnlyList<FileStationItem> fileStationItems,
        HttpResponseMessage? httpResponse)
    {
        if (httpResponse is null || fileStationItems.Count < 1)
            return;

        var filename = "download.zip";

        if (fileStationItems.Count == 1)
        {
            var fileStationItem = fileStationItems[0];
            filename = fileStationItem.Name;
        }

        var filePath = Path.Combine(absolutePath, filename);
        
        await using var stream = await httpResponse.Content.ReadAsStreamAsync()!;
        await using var fileStream = new FileStream(
            filePath, 
            FileMode.Create, 
            FileAccess.Write, 
            FileShare.None, 
            bufferSize: 8192, 
            useAsync: true);
        
        await stream.CopyToAsync(fileStream);
    }

    // Regex targets 'filename="file.extension"' string from a given string value
    [GeneratedRegex("filename=\"([^\"]+)\"")]
    private static partial Regex FilenameFromHeaderValueRegex();

    private static string ExtractFilenameFromHeaderValue(string? stringValue)
    {
        if (stringValue is null)
            return string.Empty;
        
        var match = FilenameFromHeaderValueRegex().Match(stringValue);
        
        return match.Success ? match.Groups[1].Value : string.Empty;
    }
}