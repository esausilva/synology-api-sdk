using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Synology.Api.Sdk.Config;
using Synology.Api.Sdk.SynologyApi;
using Synology.Api.Sdk.SynologyApi.ApiInfo;
using Synology.Api.Sdk.SynologyApi.Auth;
using Synology.Api.Sdk.SynologyApi.FileStation;
using Synology.Api.Sdk.SynologyApi.Foto;
using Synology.Api.Sdk.SynologyApi.FotoTeam;

namespace Synology.Api.Sdk.Tests.UnitTests.ExtensionsTests;

public class SdkConfigurationExtensionsTests
{
    [Test]
    public async Task ConfigureSynologyApiSdkDependencies_RegistersExpectedServices()
    {
        // Arrange
        var services = new ServiceCollection();
        var configuration = new ConfigurationBuilder().Build();

        // Act
        services.ConfigureSynologyApiSdkDependencies(configuration);

        // Assert
        var serviceProvider = services.BuildServiceProvider();

        // Check if options are configured correctly (this requires basic config in reality for IOptions to resolve, but we can check descriptors)
        
        // Assert individual service registrations
        await Assert.That(services.Any(sd => sd.ServiceType == typeof(ISynologyApiRequestBuilder))).IsTrue();
        await Assert.That(services.Any(sd => sd.ServiceType == typeof(ISynologyApiService))).IsTrue();
        
        await Assert.That(services.Any(sd => sd.ServiceType == typeof(IApiInfoClient))).IsTrue();
        await Assert.That(services.Any(sd => sd.ServiceType == typeof(IAuthClient))).IsTrue();
        await Assert.That(services.Any(sd => sd.ServiceType == typeof(IFileStationClient))).IsTrue();
        await Assert.That(services.Any(sd => sd.ServiceType == typeof(IFotoClient))).IsTrue();
        await Assert.That(services.Any(sd => sd.ServiceType == typeof(IFotoTeamClient))).IsTrue();
        
        await Assert.That(services.Any(sd => sd.ServiceType == typeof(ISynologyApiClient))).IsTrue();
    }
}
