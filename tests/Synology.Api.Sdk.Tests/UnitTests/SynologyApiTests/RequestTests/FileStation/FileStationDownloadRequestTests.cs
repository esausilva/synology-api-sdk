using Synology.Api.Sdk.Constants;
using Synology.Api.Sdk.SynologyApi.FileStation.Request;
using TUnit.Assertions.AssertConditions.Throws;

namespace Synology.Api.Sdk.Tests.UnitTests.SynologyApiTests.RequestTests.FileStation;

public class FileStationDownloadRequestTests : RequestTestsBase
{
    private static string? _url;
    private static readonly IReadOnlyList<string> TestPaths = ["/path1", "/path2"];
    
    [Before(Class)]
    public static void Setup_Request()
    {
        Setup_RequestBuilder();
        
        var requestBase = new FileStationDownloadRequest(
            version: 2,
            method: SynologyApiMethods.FileStation.Download_Download,
            synoToken: "test-syno-token",
            path: TestPaths,
            mode: "open");
        
        _url = SynologyApiRequestBuilder!.BuildUrl(requestBase);
    }
    
    [Test]
    public async Task Assert_Api_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains($"api={SynologyApis.FileStation.Download}");
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
            .Contains($"method={SynologyApiMethods.FileStation.Download_Download}");
    }
    
    [Test]
    public async Task Assert_SynoToken_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("SynoToken=test-syno-token");
    }
    
    [Test]
    public async Task Assert_Path_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("path=[\"%2Fpath1\",\"%2Fpath2\"]");
    }
    
    [Test]
    public async Task Assert_Mode_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("mode=open");
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_SynoToken_Is_Null()
    {
        await Assert
            .That(() =>
            {
                _ = new FileStationDownloadRequest(
                    version: 2,
                    method: "download",
                    synoToken: null!,
                    path: TestPaths);
            })
            .ThrowsExactly<ArgumentNullException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_SynoToken_Is_Empty()
    {
        await Assert
            .That(() =>
            {
                _ = new FileStationDownloadRequest(
                    version: 2,
                    method: "download",
                    synoToken: "",
                    path: TestPaths);
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_SynoToken_Is_WhiteSpace()
    {
        await Assert
            .That(() =>
            {
                _ = new FileStationDownloadRequest(
                    version: 2,
                    method: "download",
                    synoToken: "   ",
                    path: TestPaths);
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Path_Is_Null()
    {
        await Assert
            .That(() =>
            {
                _ = new FileStationDownloadRequest(
                    version: 2,
                    method: "download",
                    synoToken: "test-syno-token",
                    path: null!);
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Path_Is_Empty()
    {
        await Assert
            .That(() =>
            {
                _ = new FileStationDownloadRequest(
                    version: 2,
                    method: "download",
                    synoToken: "test-syno-token",
                    path: []);
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Version_Is_Zero()
    {
        await Assert
            .That(() =>
            {
                _ = new FileStationDownloadRequest(
                    version: 0,
                    method: "download",
                    synoToken: "test-syno-token",
                    path: TestPaths);
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Version_Is_Negative()
    {
        await Assert
            .That(() =>
            {
                _ = new FileStationDownloadRequest(
                    version: -1,
                    method: "download",
                    synoToken: "test-syno-token",
                    path: TestPaths);
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Method_Is_Null()
    {
        await Assert
            .That(() =>
            {
                _ = new FileStationDownloadRequest(
                    version: 2,
                    method: null!,
                    synoToken: "test-syno-token",
                    path: TestPaths);
            })
            .ThrowsExactly<ArgumentNullException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Method_Is_Empty()
    {
        await Assert
            .That(() =>
            {
                _ = new FileStationDownloadRequest(
                    version: 2,
                    method: "",
                    synoToken: "test-syno-token",
                    path: TestPaths);
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Method_Is_WhiteSpace()
    {
        await Assert
            .That(() =>
            {
                _ = new FileStationDownloadRequest(
                    version: 2,
                    method: "   ",
                    synoToken: "test-syno-token",
                    path: TestPaths);
            })
            .ThrowsExactly<ArgumentException>();
    }
}