using Synology.Api.Sdk.Constants;
using Synology.Api.Sdk.SynologyApi.FileStation.Request;
using TUnit.Assertions.AssertConditions.Throws;

namespace Synology.Api.Sdk.Tests.UnitTests.SynologyApiTests.RequestTests.FileStation;

public class FileStationSearchRequestTests : RequestTestsBase
{
    private static string? _url;
    private static readonly IReadOnlyList<string> TestFolderPaths = ["/folder1", "/folder2"];
    private static readonly IReadOnlyList<string> TestAdditional = ["real_path", "size", "time"];
    
    [Before(Class)]
    public static void Setup_Request()
    {
        Setup_RequestBuilder();
        
        var requestBase = new FileStationSearchRequest(
            version: 2,
            method: SynologyApiMethods.FileStation.Search_Start,
            synoToken: "test-syno-token",
            folderPaths: TestFolderPaths,
            fileType: "file",
            pattern: "test*",
            extension: "txt",
            recursive: true,
            taskId: "task123",
            offset: 0,
            limit: 100,
            additional: TestAdditional);
        
        _url = SynologyApiRequestBuilder!.BuildUrl(requestBase);
    }
    
    [Test]
    public async Task Assert_Api_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains($"api={SynologyApis.FileStation.Search}");
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
            .Contains($"method={SynologyApiMethods.FileStation.Search_Start}");
    }
    
    [Test]
    public async Task Assert_SynoToken_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("SynoToken=test-syno-token");
    }
    
    [Test]
    public async Task Assert_FolderPaths_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("folder_path=[\"%2Ffolder1\",\"%2Ffolder2\"]");
    }
    
    [Test]
    public async Task Assert_FileType_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("filetype=file");
    }
    
    [Test]
    public async Task Assert_Pattern_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("pattern=test%2A");
    }
    
    [Test]
    public async Task Assert_Extension_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("extension=txt");
    }
    
    [Test]
    public async Task Assert_Recursive_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("recursive=true");
    }
    
    [Test]
    public async Task Assert_TaskId_QueryParam_Is_Mapped()
    {
        await Assert
            .That(_url)
            .Contains("taskid=%22task123%22");
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
    public async Task Assert_Request_Throws_Exception_When_SynoToken_Is_Null()
    {
        await Assert
            .That(() =>
            {
                _ = new FileStationSearchRequest(
                    version: 2,
                    method: SynologyApiMethods.FileStation.Search_Start,
                    synoToken: null!,
                    folderPaths: TestFolderPaths);
            })
            .ThrowsExactly<ArgumentNullException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_SynoToken_Is_Empty()
    {
        await Assert
            .That(() =>
            {
                _ = new FileStationSearchRequest(
                    version: 2,
                    method: SynologyApiMethods.FileStation.Search_Start,
                    synoToken: "",
                    folderPaths: TestFolderPaths);
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_SynoToken_Is_WhiteSpace()
    {
        await Assert
            .That(() =>
            {
                _ = new FileStationSearchRequest(
                    version: 2,
                    method: SynologyApiMethods.FileStation.Search_Start,
                    synoToken: "   ",
                    folderPaths: TestFolderPaths);
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_FolderPaths_Is_Null_For_Start_Method()
    {
        await Assert
            .That(() =>
            {
                _ = new FileStationSearchRequest(
                    version: 2,
                    method: SynologyApiMethods.FileStation.Search_Start,
                    synoToken: "test-syno-token",
                    folderPaths: null);
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_FolderPaths_Is_Empty_For_Start_Method()
    {
        await Assert
            .That(() =>
            {
                _ = new FileStationSearchRequest(
                    version: 2,
                    method: SynologyApiMethods.FileStation.Search_Start,
                    synoToken: "test-syno-token",
                    folderPaths: []);
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_TaskId_Is_Null_For_Stop_Method()
    {
        await Assert
            .That(() =>
            {
                _ = new FileStationSearchRequest(
                    version: 2,
                    method: SynologyApiMethods.FileStation.Search_Stop,
                    synoToken: "test-syno-token",
                    taskId: null);
            })
            .ThrowsExactly<ArgumentNullException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_TaskId_Is_Empty_For_Stop_Method()
    {
        await Assert
            .That(() =>
            {
                _ = new FileStationSearchRequest(
                    version: 2,
                    method: SynologyApiMethods.FileStation.Search_Stop,
                    synoToken: "test-syno-token",
                    taskId: "");
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_TaskId_Is_WhiteSpace_For_Stop_Method()
    {
        await Assert
            .That(() =>
            {
                _ = new FileStationSearchRequest(
                    version: 2,
                    method: SynologyApiMethods.FileStation.Search_Stop,
                    synoToken: "test-syno-token",
                    taskId: "   ");
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_TaskId_Is_Null_For_Clean_Method()
    {
        await Assert
            .That(() =>
            {
                _ = new FileStationSearchRequest(
                    version: 2,
                    method: SynologyApiMethods.FileStation.Search_Clean,
                    synoToken: "test-syno-token",
                    taskId: null);
            })
            .ThrowsExactly<ArgumentNullException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_TaskId_Is_Empty_For_Clean_Method()
    {
        await Assert
            .That(() =>
            {
                _ = new FileStationSearchRequest(
                    version: 2,
                    method: SynologyApiMethods.FileStation.Search_Clean,
                    synoToken: "test-syno-token",
                    taskId: "");
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_TaskId_Is_WhiteSpace_For_Clean_Method()
    {
        await Assert
            .That(() =>
            {
                _ = new FileStationSearchRequest(
                    version: 2,
                    method: SynologyApiMethods.FileStation.Search_Clean,
                    synoToken: "test-syno-token",
                    taskId: "   ");
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Version_Is_Zero()
    {
        await Assert
            .That(() =>
            {
                _ = new FileStationSearchRequest(
                    version: 0,
                    method: SynologyApiMethods.FileStation.Search_Start,
                    synoToken: "test-syno-token",
                    folderPaths: TestFolderPaths);
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Version_Is_Negative()
    {
        await Assert
            .That(() =>
            {
                _ = new FileStationSearchRequest(
                    version: -1,
                    method: SynologyApiMethods.FileStation.Search_Start,
                    synoToken: "test-syno-token",
                    folderPaths: TestFolderPaths);
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Method_Is_Null()
    {
        await Assert
            .That(() =>
            {
                _ = new FileStationSearchRequest(
                    version: 2,
                    method: null!,
                    synoToken: "test-syno-token",
                    folderPaths: TestFolderPaths);
            })
            .ThrowsExactly<ArgumentNullException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Method_Is_Empty()
    {
        await Assert
            .That(() =>
            {
                _ = new FileStationSearchRequest(
                    version: 2,
                    method: "",
                    synoToken: "test-syno-token",
                    folderPaths: TestFolderPaths);
            })
            .ThrowsExactly<ArgumentException>();
    }
    
    [Test]
    public async Task Assert_Request_Throws_Exception_When_Method_Is_WhiteSpace()
    {
        await Assert
            .That(() =>
            {
                _ = new FileStationSearchRequest(
                    version: 2,
                    method: "   ",
                    synoToken: "test-syno-token",
                    folderPaths: TestFolderPaths);
            })
            .ThrowsExactly<ArgumentException>();
    }
}