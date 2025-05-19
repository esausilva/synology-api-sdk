# LogoutRequest

> SYNO.API.Auth

Authenticated endpoint.

- Request: [LogoutRequest](../src/Synology.Api.Sdk/SynologyApi/Auth/Request/LogoutRequest.cs)
- Response: [LogoutResponse](../src/Synology.Api.Sdk/SynologyApi/Auth/Response/LogoutResponse.cs)

Sample URL

```
http://127.0.0.1:5000/webapi/entry.cgi?api=SYNO.API.Auth&version=7&method=logout&_sid=1234
```

## Methods

- `logout`

## Implementation

```csharp
var synoApiRequestBuilder = services.GetRequiredService<ISynologyApiRequestBuilder>();
var synoApiService = services.GetRequiredService<ISynologyApiService>();

var logoutRequest = new LogoutRequest(
    method: SynologyApiMethods.Api.Auth_Logout,
    version: 7,
    sid: loginResponse.Data.Sid);
var logoutUrl = synoApiRequestBuilder.BuildUrl(logoutRequest);
var logoutResponse = await synoApiService.GetAsync<LogoutResponse>(logoutUrl, cancellationToken);
```
