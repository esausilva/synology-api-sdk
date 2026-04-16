# ConsumerSample

`src/Synology.Api.Sdk.ConsumerSample/` is a console app that exercises the SDK against a real Synology NAS. It demonstrates the full API workflow: query API info, login, perform operations (FileStation search, Foto album browsing, FotoTeam downloads), then logout.

**Configuration**: Requires `appsettings.json` with `UriBase` (ServerIpOrHostname, Port) and `User` (Account, Password) sections. Credentials should be stored via .NET User Secrets (`dotnet user-secrets set "User:Account" "value"` etc.) — the app loads secrets from the assembly's UserSecretsId.

**Typical call flow** (shown in `Program.cs`):
1. `ApiInfoRequest` → discover available API versions
2. `LoginRequest` → authenticate, receive `SynoToken`/`Sid`
3. API calls using `SynoToken` for auth (FileStation, Foto, FotoTeam)
4. `LogoutRequest` → end session

For file downloads, use `GetRawResponseAsync` + `DownloadHelpers.DownloadImageOrZipFromFotoApi` instead of the typed `GetAsync<T>`.