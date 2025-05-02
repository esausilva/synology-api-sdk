using System.Net;
using NSubstitute;
using Synology.Api.Sdk.SynologyApi;
using Synology.Api.Sdk.SynologyApi.Auth.Response;
using Synology.Api.Sdk.Tests.Extensions;

namespace Synology.Api.Sdk.Tests.UnitTests.SynologyApiTests.SynologyApiServiceTests;

public class GetAsyncTests
{
    private static SynologyApiService? _synologyApiService;
    private static IHttpClientFactory? _mockHttpClientFactory;
    private static HttpMessageHandler? _mockHttpMessageHandler;
    private static LoginResponse? _result;
    
    [Before(Class)]
    public static void Setup_SynologyApiService()
    {
        const string responseString = """
                           {
                             "data": {
                               "account": "admin",
                               "device_id": "device_id",
                               "ik_message": "",
                               "is_portal_port": false,
                               "sid": "sid",
                               "synotoken": "synotoken"
                             },
                             "success": true
                           }
                           """;
        
        _mockHttpMessageHandler = Substitute.ForPartsOf<HttpMessageHandler>();
        _mockHttpClientFactory = Substitute.For<IHttpClientFactory>();
        var httpClient = new HttpClient(_mockHttpMessageHandler);
        var mockResponse = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(responseString)
        };
        
        _mockHttpMessageHandler
            .SendAsync(Arg.Any<HttpRequestMessage>(), Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(mockResponse));
        
        _mockHttpClientFactory
            .CreateClient(Arg.Any<string>())
            .Returns(httpClient);
        
        _synologyApiService = new SynologyApiService(_mockHttpClientFactory);
    }

    [Test]
    public async Task Assert_GetAsync_Response_Is_NotNull()
    {
        _result = await _synologyApiService!
            .GetAsync<LoginResponse>("https://github.com/esausilva");
        
        await Assert
            .That(_result)
            .IsNotNull();
    }

    [Test]
    [DependsOn(nameof(Assert_GetAsync_Response_Is_NotNull))]
    public void Validate_Mocks()
    {
        _mockHttpClientFactory!
            .Received(1)
            .CreateClient(Arg.Any<string>());
        
        _mockHttpMessageHandler!
            .Received(1)
            .SendAsync(Arg.Any<HttpRequestMessage>(), Arg.Any<CancellationToken>());
    }

    [Test]
    [DependsOn(nameof(Assert_GetAsync_Response_Is_NotNull))]
    public async Task Assert_GetAsync_Response_Status_Code_Is_OK()
    {
        await Assert
            .That(_result!.StatusCode)
            .IsEqualTo(HttpStatusCode.OK);
    }
    
    [Test]
    [DependsOn(nameof(Assert_GetAsync_Response_Is_NotNull))]
    public async Task Assert_GetAsync_Response_Is_LoginResponse()
    {
        await Assert
            .That(_result)
            .IsAssignableTo<LoginResponse>();
    }
    
    [Test]
    [DependsOn(nameof(Assert_GetAsync_Response_Is_NotNull))]
    public async Task Assert_GetAsync_Response_Has_ErrorResponse_As_Null()
    {
        await Assert
            .That(_result!.Error)
            .IsNull();
    }
}