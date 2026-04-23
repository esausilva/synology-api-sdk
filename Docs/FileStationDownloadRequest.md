# FileStationDownloadRequest

> SYNO.FileStation.Download

Authenticated endpoint.

- Request: [FileStationDownloadRequest](../src/Synology.Api.Sdk/SynologyApi/FileStation/Request/FileStationDownloadRequest.cs)
- Response: [RawResponse](../src/Synology.Api.Sdk/SynologyApi/Shared/Response/RawResponse.cs)

Sample URL

```
http://127.0.0.1:5000/webapi/entry.cgi?api=SYNO.FileStation.Download&version=2&method=download&path=["/photo/path1/photo.jpg","/photo/path2/photo2.jpg"]&mode="download"&SynoToken=12345
```

## Methods

- `download`

## Implementation

```csharp
var synoApiRequestBuilder = services.GetRequiredService<ISynologyApiRequestBuilder>();
var synoApiService = services.GetRequiredService<ISynologyApiService>();

var fileStationDownloadRequest = new FileStationDownloadRequest(
    version: 2,
    method: SynologyApiMethods.FileStation.Download_Download,
    synoToken: loginResponse.Data.SynoToken!,
    mode: "download",
    path: ["/photo/path1/photo.jpg","/photo/path2/photo2.jpg"]);
var fileStationDownloadUrl = synoApiRequestBuilder.BuildUrl(fileStationDownloadRequest);
var fileStationDownloadResponse = await synoApiService.GetRawResponseAsync(fileStationDownloadUrl, cancellationToken);

await DownloadHelpers.DownloadImageOrZipFromFileStationApi(
    Directory.GetCurrentDirectory(), 
    fileStationSearchListResponse.Data.Files,
    fileStationDownloadResponse.HttpResponse);
```

### Notes

The static method [DownloadHelpers.DownloadImageOrZipFromFileStationApi](../src/Synology.Api.Sdk/SynologyApi/Helpers/DownloadHelpers.cs) downloads an image or ZIP file from the FileStation API and saves it to the specified path.

The second argument in the download helper method comes from the response from [FileStationSearchRequest](../src/Synology.Api.Sdk/SynologyApi/FileStation/Request/FileStationSearchRequest.cs) with the `list` method.

You do not have to use this method to download the file, it is only provided for your convenience. [GetRawResponseAsync](../src/Synology.Api.Sdk/SynologyApi/ISynologyApiService.cs) returns [RawResponse](../src/Synology.Api.Sdk/SynologyApi/Shared/Response/RawResponse.cs), which includes the HTTP Response to do with it as you wish.

### Known Limitations

#### URL Length & Request-URI Too Large (HTTP 414)

The current implementation of `FileStationDownloadRequest` relies on a `GET` request where all requested file paths are serialized into the query string. Synology NAS systems (and many reverse proxies) have a strict limit on the maximum length of a URL. When requesting a large number of files (typically exceeding 50-70 items), the resulting URL may exceed this limit, causing the NAS to return an HTTP 414 error.

While `GetRawResponseAsync` correctly reports the non-successful status code (such as HTTP 414) in its `StatusCode` property and `Success` flag, consumers must still check these values before attempting to process the response body. Failing to do so may lead to treating an HTML error page as a valid ZIP file.

#### Recommended Consumer Solution: Chunking

To handle a large number of file downloads reliably, SDK consumers should implement a **chunking strategy**. Instead of requesting all files in a single call, split the list of file paths into smaller, manageable batches (e.g., 50 items per request).

The process involves:

1.  Partitioning the total list of items into discrete batches.
2.  Iteratively calling the download endpoint for each batch.
3.  Immediately processing and extracting the resulting ZIP file for each batch before initiating the next request.

This approach ensures that each individual request remains within safe URL length constraints while still allowing for the download of an unlimited total number of files.

For a sample implementation, refer to my [Synology Photos Slideshow API](https://github.com/esausilva/synology-photos-slideshow-api)
