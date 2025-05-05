using Synology.Api.Sdk.Constants;
using Synology.Api.Sdk.SynologyApi.Auth.Request;

namespace Synology.Api.Sdk.Tests.UnitTests.SynologyApiTests.RequestTests.Auth;

public class LogoutRequestTests : RequestTestsBase
{
    private static string? _url;
    
    [Before(Class)]
    public static void Setup_Request()
    {
        Setup_RequestBuilder();
        
        var requestBase = new LogoutRequest(
            version: 1,
            method: SynologyApiMethods.Api.Auth_Logout,
            sid: "sid");
        
        _url = SynologyApiRequestBuilder!.BuildUrl(requestBase);
    }
    
    [Test]
    public async Task Assert_Api_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains($"api={SynologyApis.Api.Auth}");
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
            .Contains($"method={SynologyApiMethods.Api.Auth_Logout}");
    }
    
    [Test]
    public async Task Assert_Sid_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("_sid=sid");
    }
}