using Microsoft.Extensions.Options;
using Synology.Api.Sdk.Config;
using Synology.Api.Sdk.Constants;
using Synology.Api.Sdk.SynologyApi;
using Synology.Api.Sdk.SynologyApi.Auth.Request;

namespace Synology.Api.Sdk.Tests.UnitTests.SynologyApiTests;

public class SynologyApiRequestBuilderTests
{
    private static LoginRequest? _request;
    
    [Before(Class)]
    public static void Setup_Request()
    {
        _request = new LoginRequest(
            method: SynologyApiMethods.Api.Auth_Login,
            version: 2,
            account: "admin",
            password: "passwd");
    }
    
    [Test]
    public async Task Assert_BuildUrl_Contains_Correct_QueryString()
    {
        var uriBase = new UriBase
        {
            ServerIpOrHostname = "localhost",
            Port = 5000
        };
        var options = Options.Create(uriBase);
        var requestBuilder = new SynologyApiRequestBuilder(options);
        var url = requestBuilder.BuildUrl(_request!);
        
        using var _ = Assert.Multiple();

        await Assert
            .That(url)
            .Contains("account=admin");

        await Assert
            .That(url)
            .Contains("passwd=passwd");

        await Assert
            .That(url)
            .Contains("enable_syno_token=yes");

        await Assert
            .That(url)
            .Contains("version=2");

        await Assert
            .That(url)
            .Contains("api=SYNO.API.Auth");
        
        await Assert
            .That(url)
            .Contains("method=login");
    }
    
    [Test]
    [Arguments(true, "https")]
    [Arguments(false, "http")]
    public async Task Assert_BuildUrl_Has_Correct_Scheme(bool isHttps, string scheme)
    {
        var uriBase = new UriBase
        {
            ServerIpOrHostname = "localhost",
            Port = 5000,
            UseHttps = isHttps
        };
        var options = Options.Create(uriBase);
        var requestBuilder = new SynologyApiRequestBuilder(options);
        var url = requestBuilder.BuildUrl(_request!);
        
        await Assert
            .That(url)
            .Contains($"{scheme}://");
    }
    
    [Test]
    [Arguments(5000, "localhost:5000")]
    [Arguments(null, "localhost")]
    public async Task Assert_BuildUrl_Port_Value(int? port, string domain)
    {
        var uriBase = new UriBase
        {
            ServerIpOrHostname = "localhost",
            Port = port
        };
        var options = Options.Create(uriBase);
        var requestBuilder = new SynologyApiRequestBuilder(options);
        var url = requestBuilder.BuildUrl(_request!);
        
        await Assert
            .That(url)
            .Contains(domain);
    }
}