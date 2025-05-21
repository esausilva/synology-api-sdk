# FileStationSearchRequest

> SYNO.FileStation.Search

Authenticated endpoint.

- Request: [FileStationSearchRequest](../src/Synology.Api.Sdk/SynologyApi/FileStation/Request/FileStationSearchRequest.cs)
- Response: [FileStationSearchStartResponse](../src/Synology.Api.Sdk/SynologyApi/FileStation/Response/FileStationSearchStartResponse.cs), [FileStationSearchStopResponse](../src/Synology.Api.Sdk/SynologyApi/FileStation/Response/FileStationSearchStopResponse.cs), [FileStationSearchListResponse](../src/Synology.Api.Sdk/SynologyApi/FileStation/Response/FileStationSearchListResponse.cs), [FileStationSearchCleanResponse](../src/Synology.Api.Sdk/SynologyApi/FileStation/Response/FileStationSearchCleanResponse.cs)

Sample URL

```
http://127.0.0.1:5000/webapi/entry.cgi?api=SYNO.FileStation.Search&version=2&method=start&folder_path=["/photo/Vacation"]&SynoToken=12345&filetype="file"
```

## Methods

- `start`
- `list`
- `stop`
- `clean`

## Implementation

```csharp
var synoApiRequestBuilder = services.GetRequiredService<ISynologyApiRequestBuilder>();
var synoApiService = services.GetRequiredService<ISynologyApiService>();

var fileStationSearchStartRequest = new FileStationSearchRequest(
    version: 2,
    method: SynologyApiMethods.FileStation.Search_Start,
    synoToken: loginResponse.Data.SynoToken!,
    folderPaths: ["/photo/Vacation"],
    fileType: "file"
);
var fileStationSearchUrl = synoApiRequestBuilder.BuildUrl(fileStationSearchStartRequest);
var fileStationSearchStartResponse = await synoApiService.GetAsync<FileStationSearchStartResponse>(fileStationSearchUrl, cancellationToken);
```
