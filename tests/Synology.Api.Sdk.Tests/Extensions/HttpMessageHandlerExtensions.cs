using System.Reflection;

namespace Synology.Api.Sdk.Tests.Extensions;

internal static class HttpMessageHandlerExtensions
{
    internal static Task<HttpResponseMessage> SendAsync(this HttpMessageHandler handler, HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var sendAsync = handler.GetType()
            .GetMethod("SendAsync", BindingFlags.NonPublic | BindingFlags.Instance)!;

        return (Task<HttpResponseMessage>)
            sendAsync.Invoke(
                handler,
                [request, cancellationToken])!;
    }
}