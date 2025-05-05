using Microsoft.Extensions.Options;
using Synology.Api.Sdk.Config;
using Synology.Api.Sdk.SynologyApi;

namespace Synology.Api.Sdk.Tests.UnitTests.SynologyApiTests.RequestTests;

public class RequestTestsBase
{
    internal static SynologyApiRequestBuilder? SynologyApiRequestBuilder;

    protected static void Setup_RequestBuilder()
    {
        var uriBase = new UriBase
        {
            ServerIpOrHostname = "localhost",
            Port = 5000
        };
        var options = Options.Create(uriBase);
        SynologyApiRequestBuilder = new SynologyApiRequestBuilder(options);
    }
}