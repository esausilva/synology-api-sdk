using Synology.Api.Sdk.Constants;
using Synology.Api.Sdk.SynologyApi.FotoTeam.Request;
using TUnit.Assertions.AssertConditions.Throws;

namespace Synology.Api.Sdk.Tests.UnitTests.SynologyApiTests.RequestTests.FotoTeam;

public class FotoTeamSearchSearchRequestTests : RequestTestsBase
{
    private static string? _url;
    
    [Before(Class)]
    public static void Setup_Request()
    {
        Setup_RequestBuilder();
        
        var requestBase = new FotoTeamSearchSearchRequest(
            version: 2,
            method: "search",
            synoToken: "test-syno-token",
            keyword: "vacation");
        
        _url = SynologyApiRequestBuilder!.BuildUrl(requestBase);
    }
    
    [Test]
    public async Task Assert_Api_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains($"api={SynologyApis.FotoTeam.SearchSearch}");
    }
    
    [Test]
    public async Task Assert_Version_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("version=2");
    }
    
    [Test]
    public async Task Assert_Method_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("method=search");
    }
    
    [Test]
    public async Task Assert_SynoToken_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("SynoToken=test-syno-token");
    }
    
    [Test]
    public async Task Assert_Keyword_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("keyword=vacation");
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_SynoToken_Is_Null()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamSearchSearchRequest(
                    version: 2,
                    method: "search",
                    synoToken: null!,
                    keyword: "vacation");
            })
            .ThrowsExactly<ArgumentNullException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_SynoToken_Is_Empty()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamSearchSearchRequest(
                    version: 2,
                    method: "search",
                    synoToken: "",
                    keyword: "vacation");
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_SynoToken_Is_WhiteSpace()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamSearchSearchRequest(
                    version: 2,
                    method: "search",
                    synoToken: "   ",
                    keyword: "vacation");
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Keyword_Is_Null()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamSearchSearchRequest(
                    version: 2,
                    method: "search",
                    synoToken: "test-syno-token",
                    keyword: null!);
            })
            .ThrowsExactly<ArgumentNullException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Keyword_Is_Empty()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamSearchSearchRequest(
                    version: 2,
                    method: "search",
                    synoToken: "test-syno-token",
                    keyword: "");
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Keyword_Is_WhiteSpace()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamSearchSearchRequest(
                    version: 2,
                    method: "search",
                    synoToken: "test-syno-token",
                    keyword: "   ");
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Version_Is_Zero()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamSearchSearchRequest(
                    version: 0,
                    method: "search",
                    synoToken: "test-syno-token",
                    keyword: "vacation");
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Version_Is_Negative()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamSearchSearchRequest(
                    version: -1,
                    method: "search",
                    synoToken: "test-syno-token",
                    keyword: "vacation");
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Method_Is_Null()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamSearchSearchRequest(
                    version: 2,
                    method: null!,
                    synoToken: "test-syno-token",
                    keyword: "vacation");
            })
            .ThrowsExactly<ArgumentNullException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Method_Is_Empty()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamSearchSearchRequest(
                    version: 2,
                    method: "",
                    synoToken: "test-syno-token",
                    keyword: "vacation");
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Method_Is_WhiteSpace()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamSearchSearchRequest(
                    version: 2,
                    method: "   ",
                    synoToken: "test-syno-token",
                    keyword: "vacation");
            })
            .ThrowsExactly<ArgumentException>();
    }
}