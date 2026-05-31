using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Synology.Api.Sdk.SynologyApi;
using Synology.Api.Sdk.SynologyApi.ApiInfo;
using Synology.Api.Sdk.SynologyApi.Auth;
using Synology.Api.Sdk.SynologyApi.FileStation;
using Synology.Api.Sdk.SynologyApi.Foto;
using Synology.Api.Sdk.SynologyApi.FotoTeam;
using static Synology.Api.Sdk.Constants.SdkConstants;

namespace Synology.Api.Sdk.Config;

public static class SdkConfigurationExtensions
{
    public static IServiceCollection ConfigureSynologyApiSdkDependencies(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services
            .AddOptionsWithValidateOnStart<UriBase>()
            .ValidateDataAnnotations()
            .Bind(configuration.GetSection(nameof(UriBase)));

        services
            .AddHttpClient(SynologyApiHttpClient)
            .AddStandardResilienceHandler();

        services.AddTransient<ISynologyApiRequestBuilder, SynologyApiRequestBuilder>();
        services.AddTransient<ISynologyApiService, SynologyApiService>();
        
        services.AddTransient<IApiInfoClient, ApiInfoClient>();
        services.AddTransient<IAuthClient, AuthClient>();
        services.AddTransient<IFileStationClient, FileStationClient>();
        services.AddTransient<IFotoClient, FotoClient>();
        services.AddTransient<IFotoTeamClient, FotoTeamClient>();
        
        services.AddTransient<ISynologyApiClient, SynologyApiClient>();

        return services;
    }
}