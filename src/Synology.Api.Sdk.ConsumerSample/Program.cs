﻿using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Synology.Api.Sdk.Config;
using Synology.Api.Sdk.SynologyApi;
using Synology.Api.Sdk.SynologyApi.ApiInfo.Request;
using Synology.Api.Sdk.SynologyApi.ApiInfo.Response;
using Synology.Api.Sdk.SynologyApi.Auth.Request;
using Synology.Api.Sdk.SynologyApi.Auth.Response;
using Synology.Api.Sdk.SynologyApi.Foto.Request;
using Synology.Api.Sdk.SynologyApi.Foto.Response;

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

var synoApiRequestBuilder = services.GetRequiredService<ISynologyApiRequestBuilder>();
var synoApiService = services.GetRequiredService<ISynologyApiService>();
var cancellationToken = GenerateCancellationToken();

// ------ ApiInfo
var apiInfoRequest = new ApiInfoRequest(
    method: "query",
    version: 1);
var apiInfoUrl = synoApiRequestBuilder.BuildUrl(apiInfoRequest);
var apiInfoResponse = await synoApiService.GetAsync<ApiInfoResponse>(apiInfoUrl, cancellationToken);

Console.WriteLine(apiInfoUrl);
Console.WriteLine(SerializeResponse(apiInfoResponse));

// ------ ApiAuth - Login
var loginRequest = new LoginRequest(
    method: "login",
    version: apiInfoResponse.Data.SynoApiAuth.MaxVersion,
    account: configuration["User:Account"]!,
    password: configuration["User:Password"]!);
var loginUrl = synoApiRequestBuilder.BuildUrl(loginRequest);
var loginResponse = await synoApiService.GetAsync<LoginResponse>(loginUrl, cancellationToken);

Console.WriteLine(loginUrl);
Console.WriteLine(SerializeResponse(loginResponse));

// ------ Foto.Browse.Album
var fotoBrowseAlbumRequest = new FotoBrowseAlbumRequest(
    version: apiInfoResponse.Data.SynoFotoBrowseAlbum.MaxVersion,
    method: "list",
    offset: 0,
    limit: 10,
    synoToken: loginResponse.Data.SynoToken!);
var fotoBrowseAlbumUrl = synoApiRequestBuilder.BuildUrl(fotoBrowseAlbumRequest);
var fotoBrowseAlbumResponse = await synoApiService.GetAsync<FotoBrowseAlbumResponse>(fotoBrowseAlbumUrl, cancellationToken);

Console.WriteLine(fotoBrowseAlbumUrl);
Console.WriteLine(SerializeResponse(fotoBrowseAlbumResponse));

// ------ ApiAuth - Logout
var logoutRequest = new LogoutRequest(
    method: "logout",
    version: apiInfoResponse.Data.SynoApiAuth.MaxVersion,
    sid: loginResponse.Data.Sid);
var logoutUrl = synoApiRequestBuilder.BuildUrl(logoutRequest);
var logoutResponse = await synoApiService.GetAsync<LogoutResponse>(logoutUrl, cancellationToken);

Console.WriteLine(logoutUrl);
Console.WriteLine(SerializeResponse(logoutResponse));

await host.RunAsync();

return;

static string SerializeResponse<T>(T response) where T : class
{
    return JsonSerializer.Serialize(response, new JsonSerializerOptions { WriteIndented = true });
}

static CancellationToken GenerateCancellationToken()
{
    var cancellationTokenSource = new CancellationTokenSource();
    return cancellationTokenSource.Token;
}
