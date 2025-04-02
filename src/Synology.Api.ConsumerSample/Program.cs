using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Synology.Api.Sdk.Config;
using Synology.Api.Sdk.Constants;
using Synology.Api.Sdk.SynologyApi;
using Synology.Api.Sdk.SynologyApi.Auth.Request;

var builder = Host.CreateDefaultBuilder(args);

var host = builder.ConfigureAppConfiguration((context, config) =>
    {
        config.AddConfiguration(context.Configuration);
        config.AddUserSecrets(typeof(Program).Assembly);
    })
    .ConfigureServices((context, collection) =>
    {
        collection.ConfigureSynologyApiSdkDependencies(context.Configuration);
    })
    .Build();

var services = host.Services;

var request = new BuildRequest(services.GetRequiredService<IOptions<UriBase>>());

var loginRequest = new LoginRequest(
    api: SynologyApis.ApiAuth,
    method: "login",
    version: 6,
    account: "admin",
    password: "12345");
var loginUrl = request.BuildUrl(loginRequest);

Console.WriteLine(loginUrl);

var logoutRequest = new LogoutRequest(
    api: SynologyApis.ApiAuth,
    method: "logout",
    version: 6,
    sid: "<<SID>>");
var logoutUrl = request.BuildUrl(logoutRequest);

Console.WriteLine(logoutUrl);

await host.RunAsync();
