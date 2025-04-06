using Synology.Api.Sdk.SynologyApi.Shared.Response;

namespace Synology.Api.Sdk.SynologyApi;

public interface ISynologyApiService
{
    /// <summary>
    /// Sends an asynchronous GET request to the specified URL and retrieves the response.
    /// </summary>
    /// <param name="url">The URL to which the GET request will be sent (e.g., "https://api.example.com/resource").</param>
    /// <param name="cancellationToken">
    ///     A <see cref="CancellationToken"/> that can be used to cancel the operation.
    ///     Pass <c>CancellationToken.None</c> if not required.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation. When completed successfully,
    /// the task result contains the HTTP response as a Synology API Response object.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown if the <paramref name="url"/> parameter is <c>null</c> or white space.
    /// </exception>
    Task<T> GetAsync<T>(string url, CancellationToken cancellationToken) where T : ResponseBase;
}