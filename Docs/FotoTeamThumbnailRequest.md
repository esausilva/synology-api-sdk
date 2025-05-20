# FotoTeamThumbnailRequest

> SYNO.FotoTeam.Thumbnail

Authenticated endpoint.

- Request: [FotoTeamThumbnailRequest](../src/Synology.Api.Sdk/SynologyApi/FotoTeam/Request/FotoTeamThumbnailRequest.cs)
- Response: [RawResponse](../src/Synology.Api.Sdk/SynologyApi/Shared/Response/RawResponse.cs)

Sample URL

```
http://127.0.0.1:5000/webapi/entry.cgi?api=SYNO.FotoTeam.Thumbnail&version=2&id=44799&SynoToken=12345&method=get&type=unit&cache_key=44799_1699748818&size=xl
```

## Methods

- `get`

## Implementation

```csharp
var synoApiRequestBuilder = services.GetRequiredService<ISynologyApiRequestBuilder>();
var synoApiService = services.GetRequiredService<ISynologyApiService>();

var fotoTeamThumbnailRequest = new FotoTeamThumbnailRequest(
    version: 2,
    method: SynologyApiMethods.FotoTeam.Thumbnail_Get,
    type: "unit",
    synoToken: loginResponse.Data.SynoToken!,
    id: 44799,
    cacheKey: "44799_1699748818",
    size: "xl");
var fotoTeamThumbnailUrl = synoApiRequestBuilder.BuildUrl(fotoTeamThumbnailRequest);
var fotoTeamThumbnailResponse = await synoApiService.GetRawResponseAsync(fotoTeamThumbnailUrl, cancellationToken);

await DownloadHelpers.DownloadImageOrZipFromFotoApi(
  Directory.GetCurrentDirectory(), 
  fotoTeamThumbnailResponse.HttpResponse);
```

### Notes

The static method [DownloadHelpers.DownloadImageOrZipFromFotoApi](../src/Synology.Api.Sdk/SynologyApi/Helpers/DownloadHelpers.cs) downloads an image or ZIP file from the FotoTeam API and saves it to the specified path.

You do not have to use this method to download the file, it is only provided for your convenience. [GetRawResponseAsync](../src/Synology.Api.Sdk/SynologyApi/ISynologyApiService.cs) returns [RawResponse](../src/Synology.Api.Sdk/SynologyApi/Shared/Response/RawResponse.cs), which includes the HTTP Response to do with it as you wish.
