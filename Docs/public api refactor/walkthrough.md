# Synology API SDK Refactor Walkthrough

I have successfully refactored the SDK to provide a highly simplified consumer experience using domain-specific clients.

## 1. Deprecating Internal Interfaces

As discussed, `ISynologyApiService` and `ISynologyApiRequestBuilder` have been marked with the `[Obsolete]` attribute. This will yield compiler warnings for consumers, effectively communicating that these interfaces should no longer be injected directly, without introducing breaking changes immediately.

```csharp
[Obsolete("This interface will be made internal in a future SDK release. Please use ISynologyApiClient instead.")]
public interface ISynologyApiService
```

## 2. Introducing Domain-Specific Clients

I created 5 new domain-specific clients (interfaces and internal implementations):
- `IApiInfoClient`
- `IAuthClient`
- `IFileStationClient`
- `IFotoClient`
- `IFotoTeamClient`

These clients encapsulate the builder and service boilerplates. For example, the new `AuthClient` implementation looks like this:

```csharp
internal sealed class AuthClient(ISynologyApiRequestBuilder requestBuilder, ISynologyApiService apiService) : IAuthClient
{
    public Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default)
    {
        var url = requestBuilder.BuildUrl(request);
        return apiService.GetAsync<LoginResponse>(url, cancellationToken);
    }
    // ...
}
```

## 3. Creating `ISynologyApiClient`

I introduced the new root interface `ISynologyApiClient` that exposes all of the domain clients as properties. The implementing `synologyApiClient` class is registered in Dependency Injection via the updated `SdkConfigurationExtensions.cs`.

```csharp
public interface ISynologyApiClient
{
    IApiInfoClient ApiInfoApi { get; }
    IAuthClient AuthApi { get; }
    IFileStationClient FileStationApi { get; }
    IFotoClient FotoApi { get; }
    IFotoTeamClient FotoTeamApi { get; }
}
```

## 4. Consumer Experience Refactored

I successfully updated `ConsumerSample/Program.cs` to utilize the new architecture. The manual string builder steps are gone.

**Before:**
```csharp
var synoApiRequestBuilder = services.GetRequiredService<ISynologyApiRequestBuilder>();
var synoApiService = services.GetRequiredService<ISynologyApiService>();

var loginUrl = synoApiRequestBuilder.BuildUrl(loginRequest);
var loginResponse = await synoApiService.GetAsync<LoginResponse>(loginUrl, cancellationToken);
```

**After:**
```csharp
var synologyApiClient = services.GetRequiredService<ISynologyApiClient>();

var loginResponse = await synologyApiClient.AuthApi.LoginAsync(loginRequest, cancellationToken);
```

## 5. Verification

I successfully compiled the project. There were `0 Errors` and `28 Warnings` (which perfectly match the expected `[Obsolete]` warnings thrown internally within our new clients that still consume the obsolete interfaces). 

The consumer's API surface is now simplified exactly as requested!
