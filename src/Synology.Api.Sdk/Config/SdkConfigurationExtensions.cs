using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Synology.Api.Sdk.Config;

public static class SdkConfigurationExtensions
{
    public static IServiceCollection ConfigureSynologyApiSdkDependencies(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddOptions<UriBase>()
            .Bind(configuration.GetSection(nameof(UriBase)))
            .ValidateDataAnnotations()
            .ValidateOnStart();
        
        return services;
    }
}