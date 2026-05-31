using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Synology.Api.Sdk.Config;
using Synology.Api.Sdk.SynologyApi;
using Synology.Api.Sdk.SynologyApi.ApiInfo.Request;
using Synology.Api.Sdk.SynologyApi.Auth.Request;
using Synology.Api.Sdk.SynologyApi.FileStation.Request;
using Synology.Api.Sdk.SynologyApi.Foto.Request;
using Synology.Api.Sdk.SynologyApi.FotoTeam.Request;
using Synology.Api.Sdk.SynologyApi.Helpers;
using static Synology.Api.Sdk.Constants.SynologyApiMethods;

var builder = Host.CreateDefaultBuilder(args);

var host = builder.ConfigureAppConfiguration((context, configBuilder) =>
    {
        configBuilder.AddConfiguration(context.Configuration);
        configBuilder.AddUserSecrets(typeof(Program).Assembly);
    })
    .ConfigureServices((context, serviceCollection) =>
    {
        serviceCollection.ConfigureSynologyApiSdkDependencies(context.Configuration);
    })
    .Build();

var services = host.Services;
var configuration = services.GetRequiredService<IConfiguration>();

var synologyApiClient = services.GetRequiredService<ISynologyApiClient>();
var cancellationToken = GenerateCancellationToken();

// ------ ApiInfo
var apiInfoRequest = new ApiInfoRequest(
    method: Api.Info_Query,
    version: 1);
var apiInfoResponse = await synologyApiClient.ApiInfoApi.QueryAsync(apiInfoRequest, cancellationToken);

Console.WriteLine("ApiInfo Query");
Console.WriteLine(SerializeResponse(apiInfoResponse));

// ------ ApiAuth - Login
var loginRequest = new LoginRequest(
    method: Api.Auth_Login,
    version: apiInfoResponse.Data.SynoApiAuth.MaxVersion,
    account: configuration["User:Account"]!,
    password: configuration["User:Password"]!);
var loginResponse = await synologyApiClient.AuthApi.LoginAsync(loginRequest, cancellationToken);

Console.WriteLine("Auth Login");
Console.WriteLine(SerializeResponse(loginResponse));

// ------ FileStation.Search
var searchStartRequest = new FileStationSearchRequest(
    version: apiInfoResponse.Data.SynoFileStationSearch.MaxVersion,
    method: FileStation.Search_Start,
    folderPaths: ["/photo"],
    fileType: "file",
    synoToken: loginResponse.Data.SynoToken!);
var searchStartResponse = await synologyApiClient.FileStationApi.SearchStartAsync(searchStartRequest, cancellationToken);

Console.WriteLine("FileStation Search Start");
Console.WriteLine(SerializeResponse(searchStartResponse));

var searchListRequest = new FileStationSearchRequest(
    version: apiInfoResponse.Data.SynoFileStationSearch.MaxVersion,
    method: FileStation.Search_List,
    taskId: searchStartResponse.Data.TaskId,
    limit: 5,
    offset: 0,
    synoToken: loginResponse.Data.SynoToken!);
var searchListResponse = await synologyApiClient.FileStationApi.SearchListAsync(searchListRequest, cancellationToken);

Console.WriteLine("FileStation Search List");
Console.WriteLine(SerializeResponse(searchListResponse));

var searchCleanRequest = new FileStationSearchRequest(
    version:apiInfoResponse.Data.SynoFileStationSearch.MaxVersion,
    method: FileStation.Search_Clean,
    taskId: searchStartResponse.Data.TaskId,
    synoToken: loginResponse.Data.SynoToken!);
var searchCleanResponse = await synologyApiClient.FileStationApi.SearchCleanAsync(searchCleanRequest, cancellationToken);

Console.WriteLine("FileStation Search Clean");
Console.WriteLine(SerializeResponse(searchCleanResponse));

// ------ Foto.Browse.Album
var fotoBrowseAlbumRequest = new FotoBrowseAlbumRequest(
    version: apiInfoResponse.Data.SynoFotoBrowseAlbum.MaxVersion,
    method: Foto.BrowseAlbum_List,
    offset: 0,
    limit: 10,
    synoToken: loginResponse.Data.SynoToken!);
var fotoBrowseAlbumResponse = await synologyApiClient.FotoApi.BrowseAlbumAsync(fotoBrowseAlbumRequest, cancellationToken);

Console.WriteLine("Foto Browse Album");
Console.WriteLine(SerializeResponse(fotoBrowseAlbumResponse));

// ------ FotoTeam.Download
var fotoTeamDownloadRequest = new FotoTeamDownloadRequest(
    version: apiInfoResponse.Data.SynoFotoTeamDownload.MaxVersion,
    method: FotoTeam.Download_Download,
    unitId: [54828,25276,25245],
    synoToken: loginResponse.Data.SynoToken!);
var fotoTeamDownloadResponse = await synologyApiClient.FotoTeamApi.DownloadAsync(fotoTeamDownloadRequest, cancellationToken);
var currentDirectory = Directory.GetCurrentDirectory();

await DownloadHelpers.DownloadImageOrZipFromFotoApi(currentDirectory, fotoTeamDownloadResponse.HttpResponse);

Console.WriteLine("FotoTeam Download");

// ------ ApiAuth - Logout
var logoutRequest = new LogoutRequest(
    method: Api.Auth_Logout,
    version: apiInfoResponse.Data.SynoApiAuth.MaxVersion,
    sid: loginResponse.Data.Sid);
var logoutResponse = await synologyApiClient.AuthApi.LogoutAsync(logoutRequest, cancellationToken);

Console.WriteLine("Auth Logout");
Console.WriteLine(SerializeResponse(logoutResponse));

await host.RunAsync();

return;

static string SerializeResponse<T>(T response) where T : class
{
    return JsonSerializer.Serialize(response, new JsonSerializerOptions
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    });
}

static CancellationToken GenerateCancellationToken()
{
    var cancellationTokenSource = new CancellationTokenSource();
    return cancellationTokenSource.Token;
}
