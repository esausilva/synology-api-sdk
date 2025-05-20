# FotoTeamBrowseTimelineRequest

> SYNO.FotoTeam.Browse.Timeline

Authenticated endpoint.

- Request: [FotoTeamBrowseTimelineRequest](../src/Synology.Api.Sdk/SynologyApi/FotoTeam/Request/FotoTeamBrowseTimelineRequest.cs)
- Response: [FotoTeamBrowseTimelineResponse](../src/Synology.Api.Sdk/SynologyApi/FotoTeam/Response/FotoTeamBrowseTimelineResponse.cs)

Sample URL

```
http://127.0.0.1:5000/webapi/entry.cgi?api=SYNO.FotoTeam.Browse.Timeline&method=get&version=5&SynoToken=12345
```

## Methods

- `get`

## Implementation

```csharp
var synoApiRequestBuilder = services.GetRequiredService<ISynologyApiRequestBuilder>();
var synoApiService = services.GetRequiredService<ISynologyApiService>();

var fotoTeamBrowseTimelineRequest = new FotoTeamBrowseTimelineRequest(
    version: 5,
    method: SynologyApiMethods.FotoTeam.BrowseTimeline_Get,
    synoToken: loginResponse.Data.SynoToken!);
var fotoTeamBrowseTimelineUrl = synoApiRequestBuilder.BuildUrl(fotoTeamBrowseTimelineRequest);
var fotoTeamBrowseTimelineResponse = await synoApiService.GetAsync<FotoTeamBrowseTimelineResponse>(fotoTeamBrowseTimelineUrl, cancellationToken);
```
