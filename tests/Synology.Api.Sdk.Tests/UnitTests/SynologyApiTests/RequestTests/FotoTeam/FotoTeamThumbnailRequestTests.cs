using Synology.Api.Sdk.Constants;
using Synology.Api.Sdk.SynologyApi.FotoTeam.Request;
using TUnit.Assertions.AssertConditions.Throws;

namespace Synology.Api.Sdk.Tests.UnitTests.SynologyApiTests.RequestTests.FotoTeam;

public class FotoTeamThumbnailRequestTests : RequestTestsBase
{
    private static string? _url;
    
    [Before(Class)]
    public static void Setup_Request()
    {
        Setup_RequestBuilder();
        
        var requestBase = new FotoTeamThumbnailRequest(
            version: 2,
            method: "get",
            synoToken: "test-syno-token",
            id: 12345,
            cacheKey: "abcdef123456",
            type: "photo",
            size: "xl");
        
        _url = SynologyApiRequestBuilder!.BuildUrl(requestBase);
    }
    
    [Test]
    public async Task Assert_Api_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains($"api={SynologyApis.FotoTeam.Thumbnail}");
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
            .Contains("method=get");
    }
    
    [Test]
    public async Task Assert_SynoToken_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("SynoToken=test-syno-token");
    }
    
    [Test]
    public async Task Assert_Id_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("id=12345");
    }
    
    [Test]
    public async Task Assert_CacheKey_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("cache_key=abcdef123456");
    }
    
    [Test]
    public async Task Assert_Type_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("type=photo");
    }
    
    [Test]
    public async Task Assert_Size_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("size=xl");
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_SynoToken_Is_Null()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamThumbnailRequest(
                    version: 2,
                    method: "get",
                    synoToken: null!,
                    id: 12345,
                    cacheKey: "abcdef123456",
                    type: "photo",
                    size: "xl");
            })
            .ThrowsExactly<ArgumentNullException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_SynoToken_Is_Empty()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamThumbnailRequest(
                    version: 2,
                    method: "get",
                    synoToken: "",
                    id: 12345,
                    cacheKey: "abcdef123456",
                    type: "photo",
                    size: "xl");
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_SynoToken_Is_WhiteSpace()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamThumbnailRequest(
                    version: 2,
                    method: "get",
                    synoToken: "   ",
                    id: 12345,
                    cacheKey: "abcdef123456",
                    type: "photo",
                    size: "xl");
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Id_Is_Negative()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamThumbnailRequest(
                    version: 2,
                    method: "get",
                    synoToken: "test-syno-token",
                    id: -1,
                    cacheKey: "abcdef123456",
                    type: "photo",
                    size: "xl");
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_CacheKey_Is_Null()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamThumbnailRequest(
                    version: 2,
                    method: "get",
                    synoToken: "test-syno-token",
                    id: 12345,
                    cacheKey: null!,
                    type: "photo",
                    size: "xl");
            })
            .ThrowsExactly<ArgumentNullException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_CacheKey_Is_Empty()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamThumbnailRequest(
                    version: 2,
                    method: "get",
                    synoToken: "test-syno-token",
                    id: 12345,
                    cacheKey: "",
                    type: "photo",
                    size: "xl");
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_CacheKey_Is_WhiteSpace()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamThumbnailRequest(
                    version: 2,
                    method: "get",
                    synoToken: "test-syno-token",
                    id: 12345,
                    cacheKey: "   ",
                    type: "photo",
                    size: "xl");
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Type_Is_Null()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamThumbnailRequest(
                    version: 2,
                    method: "get",
                    synoToken: "test-syno-token",
                    id: 12345,
                    cacheKey: "abcdef123456",
                    type: null!,
                    size: "xl");
            })
            .ThrowsExactly<ArgumentNullException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Type_Is_Empty()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamThumbnailRequest(
                    version: 2,
                    method: "get",
                    synoToken: "test-syno-token",
                    id: 12345,
                    cacheKey: "abcdef123456",
                    type: "",
                    size: "xl");
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Type_Is_WhiteSpace()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamThumbnailRequest(
                    version: 2,
                    method: "get",
                    synoToken: "test-syno-token",
                    id: 12345,
                    cacheKey: "abcdef123456",
                    type: "   ",
                    size: "xl");
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Size_Is_Null()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamThumbnailRequest(
                    version: 2,
                    method: "get",
                    synoToken: "test-syno-token",
                    id: 12345,
                    cacheKey: "abcdef123456",
                    type: "photo",
                    size: null!);
            })
            .ThrowsExactly<ArgumentNullException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Size_Is_Empty()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamThumbnailRequest(
                    version: 2,
                    method: "get",
                    synoToken: "test-syno-token",
                    id: 12345,
                    cacheKey: "abcdef123456",
                    type: "photo",
                    size: "");
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Size_Is_WhiteSpace()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamThumbnailRequest(
                    version: 2,
                    method: "get",
                    synoToken: "test-syno-token",
                    id: 12345,
                    cacheKey: "abcdef123456",
                    type: "photo",
                    size: "   ");
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Version_Is_Zero()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamThumbnailRequest(
                    version: 0,
                    method: "get",
                    synoToken: "test-syno-token",
                    id: 12345,
                    cacheKey: "abcdef123456",
                    type: "photo",
                    size: "xl");
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Version_Is_Negative()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamThumbnailRequest(
                    version: -1,
                    method: "get",
                    synoToken: "test-syno-token",
                    id: 12345,
                    cacheKey: "abcdef123456",
                    type: "photo",
                    size: "xl");
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Method_Is_Null()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamThumbnailRequest(
                    version: 2,
                    method: null!,
                    synoToken: "test-syno-token",
                    id: 12345,
                    cacheKey: "abcdef123456",
                    type: "photo",
                    size: "xl");
            })
            .ThrowsExactly<ArgumentNullException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Method_Is_Empty()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamThumbnailRequest(
                    version: 2,
                    method: "",
                    synoToken: "test-syno-token",
                    id: 12345,
                    cacheKey: "abcdef123456",
                    type: "photo",
                    size: "xl");
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Method_Is_WhiteSpace()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamThumbnailRequest(
                    version: 2,
                    method: "   ",
                    synoToken: "test-syno-token",
                    id: 12345,
                    cacheKey: "abcdef123456",
                    type: "photo",
                    size: "xl");
            })
            .ThrowsExactly<ArgumentException>();
    }
}