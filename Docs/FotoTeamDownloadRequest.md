# FotoTeamDownloadRequest

> SYNO.FotoTeam.Download

Authenticated endpoint.

- Request: [FotoTeamDownloadRequest](../src/Synology.Api.Sdk/SynologyApi/FotoTeam/Request/FotoTeamDownloadRequest.cs)
- Response: [RawResponse](../src/Synology.Api.Sdk/SynologyApi/Shared/Response/RawResponse.cs)

Sample URL

```
http://127.0.0.1:5000/webapi/entry.cgi?api=SYNO.FotoTeam.Download&version=2&SynoToken=12345&method=download&unit_id=[54828,25276,25245]
```

## Methods

- `download`

## Implementation

```csharp
var synoApiRequestBuilder = services.GetRequiredService<ISynologyApiRequestBuilder>();
var synoApiService = services.GetRequiredService<ISynologyApiService>();

var fotoTeamDownloadRequest = new FotoTeamDownloadRequest(
    version: 2,
    method: SynologyApiMethods.FotoTeam.Download_Download,
    unitId: [54828,25276,25245],
    synoToken: loginResponse.Data.SynoToken!);
var fotoTeamDownloadUrl = synoApiRequestBuilder.BuildUrl(fotoTeamDownloadRequest);
var fotoTeamDownloadResponse = await synoApiService.GetRawResponseAsync(fotoTeamDownloadUrl, cancellationToken);

await DownloadHelpers.DownloadImageOrZipFromFotoApi(
  Directory.GetCurrentDirectory(), 
  fotoTeamDownloadResponse.HttpResponse);
```

### Notes

The static method [DownloadHelpers.DownloadImageOrZipFromFotoApi](../src/Synology.Api.Sdk/SynologyApi/Helpers/DownloadHelpers.cs) downloads an image or ZIP file from the FotoTeam API and saves it to the specified path.

You do not have to use this method to download the file, it is only provided for your convenience. [GetRawResponseAsync](../src/Synology.Api.Sdk/SynologyApi/ISynologyApiService.cs) returns [RawResponse](../src/Synology.Api.Sdk/SynologyApi/Shared/Response/RawResponse.cs), which includes the HTTP Response to do with it as you wish.
