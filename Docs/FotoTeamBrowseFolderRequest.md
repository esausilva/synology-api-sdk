# FotoTeamBrowseFolderRequest

> SYNO.FotoTeam.Browse.Folder

Authenticated endpoint.

- Request: [FotoTeamBrowseFolderRequest](../src/Synology.Api.Sdk/SynologyApi/FotoTeam/Request/FotoTeamBrowseFolderRequest.cs)
- Response: [FotoTeamBrowseFolderResponse](../src/Synology.Api.Sdk/SynologyApi/FotoTeam/Response/FotoTeamBrowseFolderResponse.cs)

Sample URL

```
http://127.0.0.1:5000/webapi/entry.cgi?api=SYNO.FotoTeam.Browse.Folder&version=2&method=list_parents&SynoToken=12345
```

## Methods

- `list_parents`
- `list`

## Implementation

```csharp
var synoApiRequestBuilder = services.GetRequiredService<ISynologyApiRequestBuilder>();
var synoApiService = services.GetRequiredService<ISynologyApiService>();

var fotoTeamBrowseFolderRequest = new FotoTeamBrowseFolderRequest(
    version: 2,
    method: SynologyApiMethods.FotoTeam.BrowseFolder_ListParents,
    synoToken: loginResponse.Data.SynoToken!);
var fotoTeamBrowseFolderUrl = synoApiRequestBuilder.BuildUrl(fotoTeamBrowseFolderRequest);
var fotoTeamBrowseFolderResponse = await synoApiService.GetAsync<FotoTeamBrowseFolderResponse>(fotoTeamBrowseFolderUrl, cancellationToken);
```
