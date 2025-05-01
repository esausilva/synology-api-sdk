using Microsoft.Extensions.Options;
using Synology.Api.Sdk.Config;
using Synology.Api.Sdk.Constants;
using Synology.Api.Sdk.SynologyApi;
using Synology.Api.Sdk.SynologyApi.FileStation.Request;
using Synology.Api.Sdk.SynologyApi.FotoTeam.Request;

namespace Synology.Api.Sdk.Tests.UnitTests.SynologyApiTests;

public class SynologyApiRequestBuilderTests
{
    private static FileStationSearchRequest? _request;
    
    [Before(Class)]
    public static void Setup_Request()
    {
        _request = new FileStationSearchRequest(
            method: SynologyApiMethods.FileStation.Search_Start,
            version: 2,
            synoToken: "synoToken",
            folderPaths: ["/path/1","/path/2"]);
    }
    
    [Test]
    public async Task Assert_Url_Contains_Correct_QueryString()
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
            .Contains("api=SYNO.FileStation.Search");
        
        await Assert
            .That(url)
            .Contains("method=start");
        
        await Assert
            .That(url)
            .Contains("version=2");

        await Assert
            .That(url)
            .Contains("SynoToken=synoToken");

        await Assert
            .That(url)
            .Contains($"folder_path=[\"{Uri.EscapeDataString("/path/1")}\",\"{Uri.EscapeDataString("/path/2")}\"]");
    }
    
    [Test]
    [Arguments(true, "https")]
    [Arguments(false, "http")]
    public async Task Assert_Url_Has_Correct_Scheme(bool isHttps, string scheme)
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
    public async Task Assert_Url_Port_Value(int? port, string domain)
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
    
    [Test]
    public async Task Assert_Url_Does_Not_Contain_Property_Without_JsonPropertyName()
    {
        var uriBase = new UriBase
        {
            ServerIpOrHostname = "localhost"
        };
        var options = Options.Create(uriBase);
        var requestBuilder = new SynologyApiRequestBuilder(options);
        var url = requestBuilder.BuildUrl(_request!);
        
        await Assert
            .That(url)
            .DoesNotContain($"{nameof(_request.AdditionalParameters)}=", 
                StringComparison.InvariantCultureIgnoreCase);
    }
    
    [Test]
    public async Task Assert_Url_Does_Not_Contain_Property_With_Null_Value()
    {
        var uriBase = new UriBase
        {
            ServerIpOrHostname = "localhost"
        };
        var options = Options.Create(uriBase);
        var requestBuilder = new SynologyApiRequestBuilder(options);
        var url = requestBuilder.BuildUrl(_request!);
        
        await Assert
            .That(url)
            .DoesNotContain($"filetype=");
    }
    
    [Test]
    public async Task Assert_Url_Contains_Correct_QueryString_With_Literal_Int_Array()
    {
        var request = new FotoTeamDownloadRequest(
            method: SynologyApiMethods.FileStation.Search_Start,
            version: 2,
            synoToken: "synoToken",
            unitId: [1,2]);
        var uriBase = new UriBase
        {
            ServerIpOrHostname = "localhost"
        };
        var options = Options.Create(uriBase);
        var requestBuilder = new SynologyApiRequestBuilder(options);
        var url = requestBuilder.BuildUrl(request!);
        
        await Assert
            .That(url)
            .Contains($"unit_id=[1,2]");
    }
}