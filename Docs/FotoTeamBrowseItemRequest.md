# FotoTeamBrowseItemRequest

> SYNO.FotoTeam.Browse.Item

Authenticated endpoint.

- Request: [FotoTeamBrowseItemRequest](../src/Synology.Api.Sdk/SynologyApi/FotoTeam/Request/FotoTeamBrowseItemRequest.cs)
- Response: [FotoTeamBrowseItemResponse](../src/Synology.Api.Sdk/SynologyApi/FotoTeam/Response/FotoTeamBrowseItemResponse.cs)

Sample URL

```
http://127.0.0.1:5000/webapi/entry.cgi?api=SYNO.FotoTeam.Browse.Item&version=6&method=list&offset=0&limit=10&additional=["thumbnail","folder"]&SynoToken=12345&folder_id=595
```

## Methods

- `list`

## Implementation

```csharp
var synoApiRequestBuilder = services.GetRequiredService<ISynologyApiRequestBuilder>();
var synoApiService = services.GetRequiredService<ISynologyApiService>();

var fotoTeamBrowseItemRequest = new FotoTeamBrowseItemRequest(
    version: 6,
    method: SynologyApiMethods.FotoTeam.BrowseItem_List,
    offset: 0,
    limit: 10,
    synoToken: loginResponse.Data.SynoToken!,
    additional: ["thumbnail","folder"],
    folderId: 595);
var fotoTeamBrowseItemUrl = synoApiRequestBuilder.BuildUrl(fotoTeamBrowseItemRequest);
var fotoTeamBrowseItemResponse = await synoApiService.GetAsync<FotoTeamBrowseItemResponse>(fotoTeamBrowseItemUrl, cancellationToken);
```
