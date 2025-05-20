# FotoTeamBrowseRecentlyAddedRequest

> SYNO.FotoTeam.Browse.RecentlyAdded

Authenticated endpoint.

- Request: [FotoTeamBrowseRecentlyAddedRequest](../src/Synology.Api.Sdk/SynologyApi/FotoTeam/Request/FotoTeamBrowseRecentlyAddedRequest.cs)
- Response: [FotoTeamBrowseRecentlyAddedResponse](../src/Synology.Api.Sdk/SynologyApi/FotoTeam/Response/FotoTeamBrowseRecentlyAddedResponse.cs)

Sample URL

```
http://127.0.0.1:5000/webapi/entry.cgi?api=SYNO.FotoTeam.Browse.RecentlyAdded&version=5&method=list&offset=0&limit=5&SynoToken=12345&additional=["thumbnail","folder"]
```

## Methods

- `list`

## Implementation

```csharp
var synoApiRequestBuilder = services.GetRequiredService<ISynologyApiRequestBuilder>();
var synoApiService = services.GetRequiredService<ISynologyApiService>();

var fotoTeamBrowseRecentlyAddedRequest = new FotoTeamBrowseRecentlyAddedRequest(
    version: 5,
    method: SynologyApiMethods.FotoTeam.BrowseRecentlyAdded_List,
    offset: 0,
    limit: 10,
    synoToken: loginResponse.Data.SynoToken!,
    additional: ["thumbnail","folder"]);
var fotoTeamBrowseRecentlyAddedUrl = synoApiRequestBuilder.BuildUrl(fotoTeamBrowseRecentlyAddedRequest);
var fotoTeamBrowseRecentlyAddedResponse = await synoApiService.GetAsync<FotoTeamBrowseRecentlyAddedResponse>(fotoTeamBrowseRecentlyAddedUrl, cancellationToken);
```
