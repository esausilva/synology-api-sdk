# FileStationListRequest

> SYNO.FileStation.List

Authenticated endpoint.

- Request: [FileStationListRequest](../src/Synology.Api.Sdk/SynologyApi/FileStation/Request/FileStationListRequest.cs)
- Response: [FileStationListFileResponse](../src/Synology.Api.Sdk/SynologyApi/FileStation/Response/FileStationListFileResponse.cs), [FileStationListShareResponse](../src/Synology.Api.Sdk/SynologyApi/FileStation/Response/FileStationListShareResponse.cs)

Sample URL

```
http://127.0.0.1:5000/webapi/entry.cgi?api=SYNO.FileStation.List&version=2&method=list_share&SynoToken=12345&limit=20&offset=0&additional=["real_path","type"]&onlywritable=false&sort_by=mtime
```

## Methods

- `list_share`
- `list`
- `getinfo`

## Implementation

```csharp
var synoApiRequestBuilder = services.GetRequiredService<ISynologyApiRequestBuilder>();
var synoApiService = services.GetRequiredService<ISynologyApiService>();

var fileStationListRequest = new FileStationListRequest(
    version: 2,
    method: SynologyApiMethods.FileStation.List_ListShare,
    offset: 0,
    limit: 20,
    synoToken: loginResponse.Data.SynoToken!,
    additional: ["real_path","type"],
    onlyWritable: false,
    sortBy: "mtime");
var fileStationListUrl = synoApiRequestBuilder.BuildUrl(fileStationListRequest);
var fileStationListResponse = await synoApiService.GetAsync<FileStationListFileResponse>(fileStationListUrl, cancellationToken);
```
