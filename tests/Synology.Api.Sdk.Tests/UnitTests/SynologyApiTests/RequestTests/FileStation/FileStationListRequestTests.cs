using Synology.Api.Sdk.Constants;
using Synology.Api.Sdk.SynologyApi.FileStation.Request;
using TUnit.Assertions.AssertConditions.Throws;

namespace Synology.Api.Sdk.Tests.UnitTests.SynologyApiTests.RequestTests.FileStation;

public class FileStationListRequestTests : RequestTestsBase
{
    private static string? _url;
    private static readonly IReadOnlyList<string> TestAdditional = ["real_path", "size", "time"];
    
    [Before(Class)]
    public static void Setup_Request()
    {
        Setup_RequestBuilder();
        
        var requestBase = new FileStationListRequest(
            version: 2,
            method: SynologyApiMethods.FileStation.List_List,
            synoToken: "test-syno-token",
            offset: 0,
            limit: 100,
            additional: TestAdditional,
            sortBy: "name",
            sortDirection: "asc",
            onlyWritable: true,
            gotoPath: "/test/goto",
            folderPath: "/test/folder",
            path: "/test/file.txt");
        
        _url = SynologyApiRequestBuilder!.BuildUrl(requestBase);
    }
    
    [Test]
    public async Task Assert_Api_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains($"api={SynologyApis.FileStation.List}");
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
            .Contains($"method={SynologyApiMethods.FileStation.List_List}");
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
    public async Task Assert_Additional_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("additional=[\"real_path\",\"size\",\"time\"]");
    }
    
    [Test]
    public async Task Assert_SortBy_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("sort_by=name");
    }
    
    [Test]
    public async Task Assert_SortDirection_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("sort_direction=asc");
    }
    
    [Test]
    public async Task Assert_OnlyWritable_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("onlywritable=true");
    }
    
    [Test]
    public async Task Assert_GoToPath_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("goto_path=%2Ftest%2Fgoto");
    }
    
    [Test]
    public async Task Assert_FolderPath_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("folder_path=%2Ftest%2Ffolder");
    }
    
    [Test]
    public async Task Assert_FilePath_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("path=%2Ftest%2Ffile.txt");
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_SynoToken_Is_Null()
    {
        await Assert
            .That(() =>
            {
                _ = new FileStationListRequest(
                    version: 2,
                    method: SynologyApiMethods.FileStation.List_List,
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
                _ = new FileStationListRequest(
                    version: 2,
                    method: SynologyApiMethods.FileStation.List_List,
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
                _ = new FileStationListRequest(
                    version: 2,
                    method: SynologyApiMethods.FileStation.List_List,
                    synoToken: "   ");
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Version_Is_Zero()
    {
        await Assert
            .That(() =>
            {
                _ = new FileStationListRequest(
                    version: 0,
                    method: SynologyApiMethods.FileStation.List_List,
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
                _ = new FileStationListRequest(
                    version: -1,
                    method: SynologyApiMethods.FileStation.List_List,
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
                _ = new FileStationListRequest(
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
                _ = new FileStationListRequest(
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
                _ = new FileStationListRequest(
                    version: 2,
                    method: "   ",
                    synoToken: "test-syno-token");
            })
            .ThrowsExactly<ArgumentException>();
    }
}