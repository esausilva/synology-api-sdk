using Synology.Api.Sdk.Constants;
using Synology.Api.Sdk.SynologyApi.Auth.Request;
using TUnit.Assertions.AssertConditions.Throws;

namespace Synology.Api.Sdk.Tests.UnitTests.SynologyApiTests.RequestTests.Auth;

public class LoginRequestTests : RequestTestsBase
{
    private static string? _url;
    
    [Before(Class)]
    public static void Setup_Request()
    {
        Setup_RequestBuilder();
        
        var requestBase = new LoginRequest(
            version: 1,
            method: SynologyApiMethods.Api.Auth_Login,
            account: "admin",
            password: "passwd");
        
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
            .Contains($"method={SynologyApiMethods.Api.Auth_Login}");
    }
    
    [Test]
    public async Task Assert_Account_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("account=admin");
    }
    
    [Test]
    public async Task Assert_Password_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("passwd=passwd");
    }
    
    [Test]
    public async Task Assert_EnableSynoToken_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("enable_syno_token=yes");
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Account_Is_Empty()
    {
        await Assert
            .That(() =>
            {
                _ = new LoginRequest(
                    version: 1,
                    method: SynologyApiMethods.Api.Auth_Login,
                    account: "",
                    password: "passwd");
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Password_Is_Empty()
    {
        await Assert
            .That(() =>
            {
                _ = new LoginRequest(
                    version: 1,
                    method: SynologyApiMethods.Api.Auth_Login,
                    account: "admin",
                    password: "");
            })
            .ThrowsExactly<ArgumentException>();
    }
}