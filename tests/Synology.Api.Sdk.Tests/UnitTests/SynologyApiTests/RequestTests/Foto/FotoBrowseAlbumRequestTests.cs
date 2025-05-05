using Synology.Api.Sdk.Constants;
using Synology.Api.Sdk.SynologyApi.Foto.Request;
using TUnit.Assertions.AssertConditions.Throws;

namespace Synology.Api.Sdk.Tests.UnitTests.SynologyApiTests.RequestTests.Foto;

public class FotoBrowseAlbumRequestTests : RequestTestsBase
{
    private static string? _url;
    
    [Before(Class)]
    public static void Setup_Request()
    {
        Setup_RequestBuilder();
        
        var requestBase = new FotoBrowseAlbumRequest(
            version: 2,
            method: "list",
            offset: 0,
            limit: 100,
            synoToken: "test-syno-token");
        
        _url = SynologyApiRequestBuilder!.BuildUrl(requestBase);
    }
    
    [Test]
    public async Task Assert_Api_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains($"api={SynologyApis.Foto.BrowseAlbum}");
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
    public async Task Assert_Offset_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("offset=0");
    }
    
    [Test]
    public async Task Assert_Limit_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("limit=100");
    }
    
    [Test]
    public async Task Assert_SynoToken_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("SynoToken=test-syno-token");
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Version_Is_Zero()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoBrowseAlbumRequest(
                    version: 0,
                    method: "list",
                    offset: 0,
                    limit: 100,
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
                _ = new FotoBrowseAlbumRequest(
                    version: -1,
                    method: "list",
                    offset: 0,
                    limit: 100,
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
                _ = new FotoBrowseAlbumRequest(
                    version: 2,
                    method: null!,
                    offset: 0,
                    limit: 100,
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
                _ = new FotoBrowseAlbumRequest(
                    version: 2,
                    method: "",
                    offset: 0,
                    limit: 100,
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
                _ = new FotoBrowseAlbumRequest(
                    version: 2,
                    method: "   ",
                    offset: 0,
                    limit: 100,
                    synoToken: "test-syno-token");
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Offset_Is_Negative()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoBrowseAlbumRequest(
                    version: 2,
                    method: "list",
                    offset: -1,
                    limit: 100,
                    synoToken: "test-syno-token");
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Limit_Is_Negative()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoBrowseAlbumRequest(
                    version: 2,
                    method: "list",
                    offset: 0,
                    limit: -1,
                    synoToken: "test-syno-token");
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_SynoToken_Is_Null()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoBrowseAlbumRequest(
                    version: 2,
                    method: "list",
                    offset: 0,
                    limit: 100,
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
                _ = new FotoBrowseAlbumRequest(
                    version: 2,
                    method: "list",
                    offset: 0,
                    limit: 100,
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
                _ = new FotoBrowseAlbumRequest(
                    version: 2,
                    method: "list",
                    offset: 0,
                    limit: 100,
                    synoToken: "   ");
            })
            .ThrowsExactly<ArgumentException>();
    }
}