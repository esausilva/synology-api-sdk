using Synology.Api.Sdk.Constants;
using Synology.Api.Sdk.SynologyApi.ApiInfo.Request;
using Synology.Api.Sdk.SynologyApi.Shared.Request;

namespace Synology.Api.Sdk.Tests.UnitTests.SynologyApiTests.RequestTests.ApiInfo;

public class ApiInfoRequestTests : RequestTestsBase
{
    private static string? _url;
    
    [Before(Class)]
    public static void Setup_Request()
    {
        Setup_RequestBuilder();
        
        var requestBase = new ApiInfoRequest(
            version: 1,
            method: SynologyApiMethods.Api.Info_Query);
        
        _url = SynologyApiRequestBuilder!.BuildUrl(requestBase);
    }
    
    [Test]
    public async Task Assert_Api_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains($"api={SynologyApis.Api.Info}");
    }
    
    [Test]
    public async Task Assert_Version_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("version=1");
    }
    
    [Test]
    public async Task Assert_Method_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains($"method={SynologyApiMethods.Api.Info_Query}");
    }
    
    [Test]
    public async Task Assert_Path_Property_Is_Not_Mapped()
    {
        await Assert
            .That(_url)
            .DoesNotContain(nameof(RequestBase.Path), StringComparison.InvariantCultureIgnoreCase);
    }
    
    [Test]
    public async Task Assert_AdditionalParameters_Property_Is_Not_Mapped()
    {
        await Assert
            .That(_url)
            .DoesNotContain(nameof(RequestBase.AdditionalParameters), StringComparison.InvariantCultureIgnoreCase);
    }
}