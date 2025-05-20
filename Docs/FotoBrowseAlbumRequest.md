# FotoBrowseAlbumRequest

> SYNO.Foto.Browse.Album

Authenticated endpoint.

- Request: [FotoBrowseAlbumRequest](../src/Synology.Api.Sdk/SynologyApi/Foto/Request/FotoBrowseAlbumRequest.cs)
- Response: [FotoBrowseAlbumResponse](../src/Synology.Api.Sdk/SynologyApi/Foto/Response/FotoBrowseAlbumResponse.cs)

Sample URL

```
http://127.0.0.1:5000/webapi/entry.cgi?api=SYNO.Foto.Browse.Album&version=5&method=list&offset=0&limit=100&SynoToken=12345
```

## Methods

- `list`

## Implementation

```csharp
var synoApiRequestBuilder = services.GetRequiredService<ISynologyApiRequestBuilder>();
var synoApiService = services.GetRequiredService<ISynologyApiService>();

var fotoBrowseAlbumRequest = new FotoBrowseAlbumRequest(
    version: 5,
    method: SynologyApiMethods.Foto.BrowseAlbum_List,
    offset: 0,
    limit: 10,
    synoToken: loginResponse.Data.SynoToken!);
var fotoBrowseAlbumUrl = synoApiRequestBuilder.BuildUrl(fotoBrowseAlbumRequest);
var fotoBrowseAlbumResponse = await synoApiService.GetAsync<FotoBrowseAlbumResponse>(fotoBrowseAlbumUrl, cancellationToken);
```
