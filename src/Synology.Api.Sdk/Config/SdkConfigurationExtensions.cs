using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Synology.Api.Sdk.SynologyApi;
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
            .AddOptions<UriBase>()
            .Bind(configuration.GetSection(nameof(UriBase)))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services
            .AddHttpClient(SynologyApiHttpClient)
            .AddStandardResilienceHandler();

        services.AddTransient<IRequestBuilder, RequestBuilder>();
        services.AddTransient<ISynologyApiService, SynologyApiService>();
        
        return services;
    }
}