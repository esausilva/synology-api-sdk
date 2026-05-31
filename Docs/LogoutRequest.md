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
var synologyApiClient = services.GetRequiredService<ISynologyApiClient>();

var logoutRequest = new LogoutRequest(
    method: SynologyApiMethods.Api.Auth_Logout,
    version: 7,
    sid: loginResponse.Data.Sid);
var logoutResponse = await synologyApiClient.AuthApi.LogoutAsync(logoutRequest, cancellationToken);
```
