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
