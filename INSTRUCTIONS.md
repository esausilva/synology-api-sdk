# PROJECT INSTRUCTIONS

NOTE TO AI: This file is symlinked to CLAUDE.md and GEMINI.md. When modifying this file, preserve all sections, including those intended for other AI tools. Do not overwrite the entire file; only edit relevant sections and specify if the operation is unique to which AI tool.

## Project Overview

.NET SDK for accessing Synology NAS APIs (DiskStation Manager). Published as `Synology.API.SDK` on NuGet. Licensed GPL-3.0. Targets **net9.0** and **net10.0**.

## Build & Test Commands

```bash
# Build the SDK
dotnet build src/Synology.Api.Sdk/Synology.Api.Sdk.csproj

# Run all tests
dotnet test tests/Synology.Api.Sdk.Tests/Synology.Api.Sdk.Tests.csproj

# Run a single test by name
dotnet test tests/Synology.Api.Sdk.Tests/Synology.Api.Sdk.Tests.csproj --filter "FullyQualifiedName~TestMethodName"

# Run the consumer sample (requires configured appsettings.json with Synology NAS connection)
dotnet run --project src/Synology.Api.Sdk.ConsumerSample/Synology.Api.Sdk.ConsumerSample.csproj

# Pack NuGet package
dotnet pack src/Synology.Api.Sdk/Synology.Api.Sdk.csproj -c Release
```

## Architecture

**Request-Response pattern**: Each Synology API endpoint has a sealed Request class (inheriting `RequestBase`) and a sealed Response class (inheriting `ResponseBase`). Requests use `[JsonPropertyName]` attributes for query parameter mapping.

**Two core interfaces**:
- `ISynologyApiRequestBuilder` — Reflects on request objects to build full API URLs with query strings
- `ISynologyApiService` — Executes HTTP GET requests; `GetAsync<T>` for JSON responses, `GetRawResponseAsync` for file downloads

**DI registration**: `SdkConfigurationExtensions.ConfigureSynologyApiSdkDependencies()` wires up HttpClient with resilience handler, options validation, and configuration binding for `UriBase`.

**Key directories under `src/Synology.Api.Sdk/SynologyApi/`**:
- `Shared/Request/RequestBase.cs` — Base class; all requests set Api, Version, Method, Path in their constructor
- `Shared/Response/` — `ResponseBase`, `RawResponse` (wraps HttpResponseMessage), `ErrorResponse`
- `Auth/`, `FileStation/`, `Foto/`, `FotoTeam/`, `ApiInfo/` — API-specific request/response pairs
- `Helpers/DownloadHelpers.cs` — File download with Content-Disposition parsing

**Constants**: `SynologyApis` holds API endpoint strings, `SynologyApiMethods` holds method name strings.

## Adding a New API Endpoint

1. Add API/method constants to `Constants/SynologyApis.cs` and `Constants/SynologyApiMethods.cs`
2. Create `Request/` and `Response/` classes under a new folder in `SynologyApi/` following existing patterns (sealed class, inherit `RequestBase`/`ResponseBase`, set Api/Version/Method/Path in constructor, use `[JsonPropertyName]` on properties)
3. Add corresponding tests in `tests/Synology.Api.Sdk.Tests/UnitTests/SynologyApiTests/RequestTests/`
4. Document the new API in `Docs/`

## Testing

Uses **TUnit** (not xUnit/NUnit) with **NSubstitute** for mocking. Key differences from xUnit:
- `[Test]` instead of `[Fact]`
- `[Arguments(...)]` instead of `[InlineData]`
- `[Before(Class)]` for class-level setup
- Async assertions: `await Assert.That(value).Contains(...)`

Test base class `RequestTestsBase` provides a pre-configured `SynologyApiRequestBuilder` instance for URL-building tests.

## ConsumerSample

`src/Synology.Api.Sdk.ConsumerSample/` is a console app that exercises the SDK against a real Synology NAS. It demonstrates the full API workflow: query API info, login, perform operations (FileStation search, Foto album browsing, FotoTeam downloads), then logout.

**Configuration**: Requires `appsettings.json` with `UriBase` (ServerIpOrHostname, Port) and `User` (Account, Password) sections. Credentials should be stored via .NET User Secrets (`dotnet user-secrets set "User:Account" "value"` etc.) — the app loads secrets from the assembly's UserSecretsId.

**Typical call flow** (shown in `Program.cs`):
1. `ApiInfoRequest` → discover available API versions
2. `LoginRequest` → authenticate, receive `SynoToken`/`Sid`
3. API calls using `SynoToken` for auth (FileStation, Foto, FotoTeam)
4. `LogoutRequest` → end session

For file downloads, use `GetRawResponseAsync` + `DownloadHelpers.DownloadImageOrZipFromFotoApi` instead of the typed `GetAsync<T>`.

## CI/CD

GitHub Actions (`ci.yml`) triggers on version tags (`v*.*.*`). Runs tests on .NET 9, then builds and publishes the NuGet package. Sensitive config uses .NET User Secrets (IDs in csproj files).
