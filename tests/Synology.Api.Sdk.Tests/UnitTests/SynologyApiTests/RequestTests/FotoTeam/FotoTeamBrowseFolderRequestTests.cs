using Synology.Api.Sdk.Constants;
using Synology.Api.Sdk.SynologyApi.FotoTeam.Request;
using TUnit.Assertions.AssertConditions.Throws;

namespace Synology.Api.Sdk.Tests.UnitTests.SynologyApiTests.RequestTests.FotoTeam;

public class FotoTeamBrowseFolderRequestTests : RequestTestsBase
{
    private static string? _url;
    
    [Before(Class)]
    public static void Setup_Request()
    {
        Setup_RequestBuilder();
        
        var requestBase = new FotoTeamBrowseFolderRequest(
            version: 2,
            method: "list",
            synoToken: "test-syno-token",
            offset: 10,
            limit: 50,
            id: 123);
        
        _url = SynologyApiRequestBuilder!.BuildUrl(requestBase);
    }
    
    [Test]
    public async Task Assert_Api_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains($"api={SynologyApis.FotoTeam.BrowseFolder}");
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
            .Contains("method=list");
    }
    
    [Test]
    public async Task Assert_SynoToken_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("SynoToken=test-syno-token");
    }
    
    [Test]
    public async Task Assert_Offset_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("offset=10");
    }
    
    [Test]
    public async Task Assert_Limit_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("limit=50");
    }
    
    [Test]
    public async Task Assert_Id_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("id=123");
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_SynoToken_Is_Null()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamBrowseFolderRequest(
                    version: 2,
                    method: "list",
                    synoToken: null!);
            })
            .ThrowsExactly<ArgumentNullException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_SynoToken_Is_Empty()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamBrowseFolderRequest(
                    version: 2,
                    method: "list",
                    synoToken: "");
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_SynoToken_Is_WhiteSpace()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamBrowseFolderRequest(
                    version: 2,
                    method: "list",
                    synoToken: "   ");
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Offset_Is_Negative()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamBrowseFolderRequest(
                    version: 2,
                    method: "list",
                    synoToken: "test-syno-token",
                    offset: -1);
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Limit_Is_Negative()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamBrowseFolderRequest(
                    version: 2,
                    method: "list",
                    synoToken: "test-syno-token",
                    limit: -1);
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Id_Is_Negative()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamBrowseFolderRequest(
                    version: 2,
                    method: "list",
                    synoToken: "test-syno-token",
                    id: -1);
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Version_Is_Zero()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamBrowseFolderRequest(
                    version: 0,
                    method: "list",
                    synoToken: "test-syno-token");
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Version_Is_Negative()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamBrowseFolderRequest(
                    version: -1,
                    method: "list",
                    synoToken: "test-syno-token");
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Method_Is_Null()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamBrowseFolderRequest(
                    version: 2,
                    method: null!,
                    synoToken: "test-syno-token");
            })
            .ThrowsExactly<ArgumentNullException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Method_Is_Empty()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamBrowseFolderRequest(
                    version: 2,
                    method: "",
                    synoToken: "test-syno-token");
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Method_Is_WhiteSpace()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamBrowseFolderRequest(
                    version: 2,
                    method: "   ",
                    synoToken: "test-syno-token");
            })
            .ThrowsExactly<ArgumentException>();
    }
}