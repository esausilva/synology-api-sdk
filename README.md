# Synology API SDK

A C# SDK to access the Synology NAS APIs in DiskStation Manager (DSM).

## Table of Contents

- [Recommendations](#recommendations)
- [Implemented APIs](#implemented-apis)
- [Installation](#installation)
- [Basic Usage](#basic-usage)
  - [ISynologyApiClient](#isynologyapiclient)
    - [Example Code](#example-code)
- [Synology API Requests](#synology-api-requests)
- [Contributing](#contributing)
- [Real World Example](#real-world-example)
- [Giving Back](#giving-back)

---

## Recommendations

I would recommend getting familiarized with the Synology APIs first before implementing this SDK, you will have a much easier time implementing it.

I have included [Bruno API Client](https://www.usebruno.com/) scripts ([Bruno Synology API Scripts](./Bruno%20Synology%20API%20Scripts/)) to make it easier.

The official Synology API documentation can be found at [Dev Center](https://www.synology.com/en-af/support/developer#tool). 

## Implemented APIs

Included implementations in this SDK are some of the FileStation APIs and some of the Photos APIs.

There is no official Photos API documentation; what I have implemented in this SDK is what I gathered from various sources, including Synology's Community Forums, other repos, etc.

| API | Description
| --- | --- |
| SYNO.API.Info | Represents a request to retrieve information about the Synology APIs available for use on the target DiskStation. |
| SYNO.API.Auth | Represents a request to authenticate to Synology NAS. |
| SYNO.FileStation.Download | Represents a request to download an item(s) from a folder or subfolder. |
| SYNO.FileStation.List | Represents a request to retrieve a list of files and folders in a directory. |
| SYNO.FileStation.Search | Represents a request to retrieve a list of files and folders in a directory based on a search criteria. |
| SYNO.Foto.Browse.Album | Represents a request to retrieve a list of albums in your Personal Space. |
| SYNO.FotoTeam.Browse.Folder | Represents a request to retrieve a list of folders in the Shared Space. |
| SYNO.FotoTeam.Browse.Item | Represents a request to retrieve a list of items within a folder in the Shared Space. |
| SYNO.FotoTeam.Browse.RecentlyAdded | Represents a request to retrieve a list of recently added items in the Shared Space. |
| SYNO.FotoTeam.Browse.Timeline | Represents a request to retrieve a list of item counts in the timeline by year and month in the Shared Space. |
| SYNO.FotoTeam.Download | Represents a request to download an item(s) in the Shared Space. |
| SYNO.FotoTeam.Search.Search | Represents a request to retrieve a count of items based on a keyword in the Shared Space. |
| SYNO.FotoTeam.Thumbnail | Represents a request to download an item's thumbnail in the Shared Space. |

## Installation

You will need to have the following in your `appsettings.json` file.

```json
{
  "UriBase": {
    "ServerIpOrHostname": "<<SERVER_IP_OR_HOSTNAME>>",
    "Port": 5000,
    "UseHttps": false 
  }
}
```

This wires up DI for the base address in [SdkConfigurationExtensions.ConfigureSynologyApiSdkDependencies](./src/Synology.Api.Sdk/Config/SdkConfigurationExtensions.cs) class.

| Option               | Required | Description                                                                                                                               |
| -------------------- | :------: | ----------------------------------------------------------------------------------------------------------------------------------------- |
| `ServerIpOrHostname` |    ✅    | Your NAS IP address or hostname. If not provided, the SDK will throw `Microsoft.Extensions.Options.OptionsValidationException` exception. |
| `Port`               |          | The NAS' default port number is `5000`.                                                                                                   |
| `UseHttps`           |          | Defaults to `false`.                                                                                                                      | 

The result will be a base URI similar to `http://127.0.0.1:5000`.

## Basic Usage

The SDK exposes a single root interface to interact with the Synology APIs, `ISynologyApiClient`.

### ISynologyApiClient

This interface provides access to domain-specific clients (e.g., `ApiInfoApi`, `AuthApi`, `FileStationApi`, `FotoApi`, `FotoTeamApi`). Each domain client handles the URL construction and HTTP execution internally.

#### Example Code

```csharp
/*
Configure Synology API SDK DI container.
*/
serviceCollection.ConfigureSynologyApiSdkDependencies(Configuration);

/*
Inject the root client used to call the Synology APIs.
*/
var synologyApiClient = services.GetRequiredService<ISynologyApiClient>();

/*
This will create a request to call SYNO.API.Info API endpoint. The properties of the request will become query parameters.
*/
var apiInfoRequest = new ApiInfoRequest(
    method: Api.Info_Query,
    version: 1);

/*
Call the specific domain API passing the request object.
The client automatically builds the URL and returns a typed response.
*/
var apiInfoResponse = await synologyApiClient.ApiInfoApi.QueryAsync(apiInfoRequest, cancellationToken);
```

I have also included a [Consumer Sample](./Docs/ConsumerSample.md) project for more complete usage examples.

## Synology API Requests

- [ApiInfoRequest](./Docs/ApiInfoRequest.md)
- [LoginRequest](./Docs/LoginRequest.md)
- [LogoutRequest](./Docs/LogoutRequest.md)
- [FileStationDownloadRequest](./Docs/FileStationDownloadRequest.md)
- [FileStationListRequest](./Docs/FileStationListRequest.md)
- [FileStationSearchRequest](./Docs/FileStationSearchRequest.md)
- [FotoBrowseAlbumRequest](./Docs/FotoBrowseAlbumRequest.md)
- [FotoTeamBrowseFolderRequest](./Docs/FotoTeamBrowseFolderRequest.md)
- [FotoTeamBrowseItemRequest](./Docs/FotoTeamBrowseItemRequest.md)
- [FotoTeamBrowseRecentlyAddedRequest](./Docs/FotoTeamBrowseRecentlyAddedRequest.md)
- [FotoTeamBrowseTimelineRequest](./Docs/FotoTeamBrowseTimelineRequest.md)
- [FotoTeamDownloadRequest](./Docs/FotoTeamDownloadRequest.md)
- [FotoTeamSearchSearchRequest](./Docs/FotoTeamSearchSearchRequest.md)
- [FotoTeamThumbnailRequest](./Docs/FotoTeamThumbnailRequest.md)

It is possible I have not included all the parameters in the official API docs for each request. If that is the case, there is an option to add additional parameters to each request via a `key`-`value` dictionary when creating the request object.

Example:

```csharp
var apiInfoRequest = new ApiInfoRequest(
    method: Api.Info_Query,
    version: 1)
{
    AdditionalParameters = new Dictionary<string, string>
    {
        { "query", "all" }
    }
};
```

## Contributing

Follow the naming conventions for Synology API Request and Response classes.

Example: 
- API endpoint: `SYNO.FileStation.List`
- Request-Response C# classes: `FileStationListRequest.cs` and `FileStationListResponse.cs`

Add corresponding unit tests following the existing tests patterns.

Make sure to test by calling your NAS and getting a successful response.

## Real World Example

[Synology Photos Slideshow API](https://github.com/esausilva/synology-photos-slideshow-api) — A .NET REST API I created that implements this SDK to download random photos from a Synology NAS, convert them to WebP, and serve them for slideshow clients. It features scheduled download jobs, real-time updates via SignalR, and optional geolocation powered by Google Maps.


## Giving Back

If you find this SDK useful in any way, consider getting me a coffee by clicking on the image below. I would really appreciate it!

[![Buy Me A Coffee](https://www.buymeacoffee.com/assets/img/custom_images/black_img.png)](https://www.buymeacoffee.com/esausilva)
