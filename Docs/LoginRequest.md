# LoginRequest

> SYNO.API.Auth

Non-authenticated endpoint.

- Request: [LoginRequest](../src/Synology.Api.Sdk/SynologyApi/Auth/Request/LoginRequest.cs)
- Response: [LoginResponse](../src/Synology.Api.Sdk/SynologyApi/Auth/Response/LoginResponse.cs)

Sample URL

```
http://127.0.0.1:5000/webapi/entry.cgi?api=SYNO.API.Auth&version=7&method=login&account=serviceaccount&passwd=passwd123&enable_syno_token=yes
```

## Methods

- `login`

## Implementation

```csharp
var synoApiRequestBuilder = services.GetRequiredService<ISynologyApiRequestBuilder>();
var synoApiService = services.GetRequiredService<ISynologyApiService>();

var loginRequest = new LoginRequest(
    method: SynologyApiMethods.Api.Auth_Login,
    version: 7,
    account: configuration["User:Account"]!,
    password: configuration["User:Password"]!);
var loginUrl = synoApiRequestBuilder.BuildUrl(loginRequest);
var loginResponse = await synoApiService.GetAsync<LoginResponse>(loginUrl, cancellationToken);
```
