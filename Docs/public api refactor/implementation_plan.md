# Simplify Public API

The current SDK architecture requires consumers to manually inject both `ISynologyApiService` and `ISynologyApiRequestBuilder`, construct the URL from a request, and specify the generic response type. This forces the consumer to remember the request-response pairs and leads to boilerplate code.

This refactoring plan introduces a Facade/Client pattern over the existing Request/Response infrastructure, so the consumer only injects a single `ISynologyApiClient`.

## Proposed Changes

### 1. Introduce Domain-Specific Interfaces

Create strongly-typed, domain-specific interfaces to group related endpoints. Each interface method will take a request object and return a `Task<ResponseBase>`.

- **`IApiInfoClient`**
  - `Task<ApiInfoResponse> QueryAsync(ApiInfoRequest request, CancellationToken cancellationToken = default)`
- **`IAuthClient`**
  - `Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default)`
  - `Task<LogoutResponse> LogoutAsync(LogoutRequest request, CancellationToken cancellationToken = default)`
- **`IFileStationClient`**
  - Search, List, and Download async methods.
- **`IFotoClient`**
  - `Task<FotoBrowseAlbumResponse> BrowseAlbumAsync(FotoBrowseAlbumRequest request, CancellationToken cancellationToken = default)`
- **`IFotoTeamClient`**
  - BrowseFolder, BrowseItem, BrowseRecentlyAdded, BrowseTimeline, Download, Search, and Thumbnail async methods.

### 2. Implement Domain Clients Internally

Implement these interfaces as `internal` classes within their respective module folders (e.g., `src/Synology.Api.Sdk/SynologyApi/Auth/AuthClient.cs`). 
Each implementation will inject `ISynologyApiRequestBuilder` and `ISynologyApiService` to hide the boilerplate.

**Example implementation:**
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

### 3. Introduce the Single Entry Interface `ISynologyApiClient`

Create a root interface that the consumer can inject as a single dependency.

```csharp
public interface ISynologyApiClient
{
    IApiInfoClient ApiInfo { get; }
    IAuthClient Auth { get; }
    IFileStationClient FileStation { get; }
    IFotoClient Foto { get; }
    IFotoTeamClient FotoTeam { get; }
}
```

Its implementation `synologyApiClient` will inject and assign all the domain-specific clients.

### 4. Update Dependency Injection

Modify `Config/SdkConfigurationExtensions.cs` to register the new interfaces.

```csharp
// Existing
services.AddTransient<ISynologyApiRequestBuilder, SynologyApiRequestBuilder>();
services.AddTransient<ISynologyApiService, SynologyApiService>();

// New Domain Clients
services.AddTransient<IApiInfoClient, ApiInfoClient>();
services.AddTransient<IAuthClient, AuthClient>();
services.AddTransient<IFileStationClient, FileStationClient>();
services.AddTransient<IFotoClient, FotoClient>();
services.AddTransient<IFotoTeamClient, FotoTeamClient>();

// Root Client
services.AddTransient<ISynologyApiClient, synologyApiClient>();
```

### 5. Update ConsumerSample

Refactor `Synology.Api.Sdk.ConsumerSample/Program.cs` to use the new `ISynologyApiClient` to demonstrate the simplified API.

## Open Questions

**Resolution**: `ISynologyApiService` and `ISynologyApiRequestBuilder` will remain public for now. We will use the `[Obsolete("This interface will be made internal in a future SDK release. Please use ISynologyApiClient instead.")]` attribute on these interfaces to warn consumers about the upcoming change without breaking their existing code.

## Verification Plan

### Automated Tests
- N/A. No unit tests currently exist that would break, but the solution must build without errors.

### Manual Verification
- Re-run `Synology.Api.Sdk.ConsumerSample` to ensure it authenticates and successfully calls all endpoints exactly as before, proving the wrapper functions correctly.
