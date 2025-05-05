using Synology.Api.Sdk.Constants;
using Synology.Api.Sdk.SynologyApi.FotoTeam.Request;
using TUnit.Assertions.AssertConditions.Throws;

namespace Synology.Api.Sdk.Tests.UnitTests.SynologyApiTests.RequestTests.FotoTeam;

public class FotoTeamDownloadRequestTests : RequestTestsBase
{
    private static string? _url;
    private static readonly IReadOnlyList<int> TestUnitIds = [123, 456, 789];
    
    [Before(Class)]
    public static void Setup_Request()
    {
        Setup_RequestBuilder();
        
        var requestBase = new FotoTeamDownloadRequest(
            version: 2,
            method: "download",
            synoToken: "test-syno-token",
            unitId: TestUnitIds);
        
        _url = SynologyApiRequestBuilder!.BuildUrl(requestBase);
    }
    
    [Test]
    public async Task Assert_Api_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains($"api={SynologyApis.FotoTeam.Download}");
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
            .Contains("method=download");
    }
    
    [Test]
    public async Task Assert_SynoToken_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("SynoToken=test-syno-token");
    }
    
    [Test]
    public async Task Assert_UnitId_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("unit_id=[123,456,789]");
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_SynoToken_Is_Null()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamDownloadRequest(
                    version: 2,
                    method: "download",
                    synoToken: null!,
                    unitId: TestUnitIds);
            })
            .ThrowsExactly<ArgumentNullException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_SynoToken_Is_Empty()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamDownloadRequest(
                    version: 2,
                    method: "download",
                    synoToken: "",
                    unitId: TestUnitIds);
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_SynoToken_Is_WhiteSpace()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamDownloadRequest(
                    version: 2,
                    method: "download",
                    synoToken: "   ",
                    unitId: TestUnitIds);
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Version_Is_Zero()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamDownloadRequest(
                    version: 0,
                    method: "download",
                    synoToken: "test-syno-token",
                    unitId: TestUnitIds);
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Version_Is_Negative()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamDownloadRequest(
                    version: -1,
                    method: "download",
                    synoToken: "test-syno-token",
                    unitId: TestUnitIds);
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Method_Is_Null()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamDownloadRequest(
                    version: 2,
                    method: null!,
                    synoToken: "test-syno-token",
                    unitId: TestUnitIds);
            })
            .ThrowsExactly<ArgumentNullException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Method_Is_Empty()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamDownloadRequest(
                    version: 2,
                    method: "",
                    synoToken: "test-syno-token",
                    unitId: TestUnitIds);
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Method_Is_WhiteSpace()
    {
        await Assert
            .That(() =>
            {
                _ = new FotoTeamDownloadRequest(
                    version: 2,
                    method: "   ",
                    synoToken: "test-syno-token",
                    unitId: TestUnitIds);
            })
            .ThrowsExactly<ArgumentException>();
    }
}