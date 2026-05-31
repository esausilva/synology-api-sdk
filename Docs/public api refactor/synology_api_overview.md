# Synology API SDK Implementation Overview

Based on the analysis of the `synology-api-sdk` codebase, here is a detailed overview of the SDK's public API surface and internal architecture.

## 1. Architectural Pattern

The SDK follows a highly declarative, **Request/Response and Builder** architectural pattern rather than relying on domain-specific client interfaces (e.g., there is no `IAuthClient` or `IFileStationClient`). Instead, all interactions flow through a unified service using strongly-typed Request and Response models. 

This approach minimizes boilerplate code for each new API endpoint and relies on the underlying Synology API convention where parameters are passed via the URL query string.

### Core Components
- `ISynologyApiService`: The HTTP runner that executes the requests.
- `ISynologyApiRequestBuilder`: The URL builder that transforms request models into Synology-compatible URL strings.
- **Request Models**: Strongly-typed classes inheriting from `RequestBase`.
- **Response Models**: Strongly-typed classes inheriting from `ResponseBase`.

## 2. Request Handling & URL Building

All API calls are initiated by creating a Request object.

- **`RequestBase`**: The foundational class for all requests. It defines the core parameters required by the Synology API: `Api` (target module), `Version`, and `Method` (the action). It also allows passing `AdditionalParameters` through a dictionary for flexibility.
- **Strongly-typed Requests**: Specific APIs implement their own requests (e.g., `LoginRequest`, `FileStationSearchRequest`). These classes define custom properties decorated with `[JsonPropertyName("...")]` (e.g., `[JsonPropertyName("account")] public string Account { get; }`).

**The Builder (`SynologyApiRequestBuilder`)**:
This is a critical piece of the implementation. When `BuildUrl<T>(T request)` is called, the builder uses **Reflection** to:
1. Iterate over all properties of the Request model.
2. Filter for properties decorated with `[JsonPropertyNameAttribute]`.
3. Read the property's value.
4. Format the value appropriately (e.g., booleans are cast to lowercase strings, and enumerables are converted into JSON array string representations like `["item1","item2"]`).
5. URL-encode the parameters and construct the final query string appended to the configured NAS base URL.

## 3. Execution & Deserialization

Once the URL is built, it's passed to `ISynologyApiService`.

- **`GetAsync<T>`**: Sends an asynchronous HTTP GET request to the built URL. It then deserializes the JSON response into the specified strongly-typed `T` response model (which must inherit from `ResponseBase`).
- **`GetRawResponseAsync`**: A fallback method for endpoints that don't return JSON. This is particularly useful for operations like downloading files from `FotoTeam`, where the response is a binary stream instead of a JSON payload. It returns a `RawResponse` object containing the `HttpResponseMessage` and success status.

## 4. Configuration and Dependency Injection

The SDK is designed to integrate seamlessly into modern .NET applications using `Microsoft.Extensions.DependencyInjection`.

- **`SdkConfigurationExtensions`**: Exposes the `ConfigureSynologyApiSdkDependencies` extension method.
- **Registration**: It registers the `ISynologyApiService` and `ISynologyApiRequestBuilder` as transient services. 
- **HTTP Client**: It registers a typed `HttpClient` using `IHttpClientFactory` and attaches standard resilience handlers (retries, circuit breakers) for robust network operations.
- **Configuration Binding**: It binds the target NAS connection settings (Host, Port, Https) from the `IConfiguration` into the strongly-typed `UriBase` options class.

## 5. Typical Consumer Workflow

As seen in the `ConsumerSample` project, consuming the SDK looks like this:

```csharp
// 1. Create a strongly-typed request model
var loginRequest = new LoginRequest(
    method: Api.Auth_Login,
    version: 7,
    account: "username",
    password: "password"
);

// 2. Build the URL
var loginUrl = synoApiRequestBuilder.BuildUrl(loginRequest);

// 3. Execute the request and get the typed response
var loginResponse = await synoApiService.GetAsync<LoginResponse>(loginUrl, cancellationToken);
```

## Conclusion

The SDK is extremely lean and maintainable. By avoiding heavy client interfaces for every Synology module (FileStation, Photo, Auth, etc.), it delegates the complexity to small, focused Request/Response Data Transfer Objects (DTOs) and uses reflection to bridge them into HTTP parameters.
