using Synology.Api.Sdk.SynologyApi.Shared.Request;

namespace Synology.Api.Sdk.SynologyApi;

public interface ISynologyApiRequestBuilder
{
    /// <summary>
    /// Constructs a URL by taking a Synology API Request
    /// </summary>
    /// <param name="request">Synology API Request</param>
    /// <returns>
    /// A string representing a complete URL to call a Synology API.
    /// </returns>
    /// <example>
    /// Example usage:
    /// <code>
    /// var apiInfoRequest = new ApiInfoRequest(
    ///     method: "query",
    ///     version: 1);
    /// var apiInfoUrl = synoApiRequestBuilder.BuildUrl(apiInfoRequest);
    /// Result: <![CDATA["https://api.example.com/users?page=1&sort=desc" ]]>
    /// </code>
    /// </example>
    string BuildUrl<T>(T request) where T : RequestBase;
}