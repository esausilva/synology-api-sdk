# ApiInfoRequest

Non-authenticated endpoint.

- Request: [ApiInfoRequest](../src/Synology.Api.Sdk/SynologyApi/ApiInfo/Request/ApiInfoRequest.cs)
- Response: [ApiInfoResponse](../src/Synology.Api.Sdk/SynologyApi/ApiInfo/Response/ApiInfoResponse.cs)

Sample URL

```
http://127.0.0.1:5000/webapi/entry.cgi?api=SYNO.API.Info&version=1&method=query
```

## Methods

- `query`

## Implementation

```csharp
var synoApiRequestBuilder = services.GetRequiredService<ISynologyApiRequestBuilder>();
var synoApiService = services.GetRequiredService<ISynologyApiService>();

var apiInfoRequest = new ApiInfoRequest(
    method: SynologyApiMethods.Api.Info_Query,
    version: 1);
var apiInfoUrl = synoApiRequestBuilder.BuildUrl(apiInfoRequest);
var apiInfoResponse = await synoApiService.GetAsync<ApiInfoResponse>(apiInfoUrl, cancellationToken);
```
