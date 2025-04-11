using Synology.Api.Sdk.SynologyApi.Shared.Response;

namespace Synology.Api.Sdk.SynologyApi;

public interface ISynologyApiService
{
    /// <summary>
    /// Sends an asynchronous GET request to the specified URL and retrieves the response.
    /// </summary>
    /// <param name="requestUrl">The URL to which the GET request will be sent
    /// (e.g., "https://api.example.com/resource").</param>
    /// <param name="cancellationToken">
    ///     A <see cref="CancellationToken"/> that can be used to cancel the operation.
    ///     Pass <c>CancellationToken.None</c> if not required.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation. When completed successfully,
    /// the task result contains the HTTP response mapped to a Synology API Response object.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown if the <paramref name="requestUrl"/> parameter is <c>null</c> or white space.
    /// </exception>
    Task<T> GetAsync<T>(string requestUrl, CancellationToken cancellationToken) where T : ResponseBase;
    
    /// <summary>
    /// Sends an asynchronous GET request to the specified URL and retrieves the response.
    /// </summary>
    /// <param name="requestUrl">The URL to which the GET request will be sent
    /// (e.g., "https://api.example.com/resource").</param>
    /// <param name="cancellationToken">
    ///     A <see cref="CancellationToken"/> that can be used to cancel the operation.
    ///     Pass <c>CancellationToken.None</c> if not required.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation. When completed successfully,
    /// the task result contains the HTTP response and returned as such.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown if the <paramref name="requestUrl"/> parameter is <c>null</c> or white space.
    /// </exception>
    Task<RawResponse> GetRawResponseAsync(string requestUrl, CancellationToken cancellationToken);
}