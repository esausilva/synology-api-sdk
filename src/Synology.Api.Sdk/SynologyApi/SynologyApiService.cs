using System.Text.Json;
using Synology.Api.Sdk.SynologyApi.Shared.Response;
using static Synology.Api.Sdk.Constants.SdkConstants;

namespace Synology.Api.Sdk.SynologyApi;

internal sealed class SynologyApiService : ISynologyApiService
{
    private readonly IHttpClientFactory _httpClientFactoryFactory;

    public SynologyApiService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactoryFactory = httpClientFactory;
    }

    public async Task<T> GetAsync<T>(string requestUrl, CancellationToken cancellationToken = default) where T : ResponseBase
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(requestUrl);
        
        using var httpClient = _httpClientFactoryFactory.CreateClient(SynologyApiHttpClient);

        var response = await httpClient.GetAsync(requestUrl, cancellationToken);
        var responseData = await response.Content.ReadAsStringAsync(cancellationToken);
        var deserialize = JsonSerializer.Deserialize<T>(responseData, 
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        
        deserialize
            .GetType()
            .GetProperty("StatusCode")?
            .SetValue(deserialize, response.StatusCode);
        
        return deserialize;
    }
    
    public async Task<RawResponse> GetRawResponseAsync(string requestUrl, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(requestUrl);
        
        using var httpClient = _httpClientFactoryFactory.CreateClient(SynologyApiHttpClient);

        var response = await httpClient.GetAsync(requestUrl, cancellationToken);
        var errorResponse = await IsErrorResponse();
        
        return errorResponse ?? new RawResponse
        {
            HttpResponse = response, 
            Success = true, 
            StatusCode = response.StatusCode
        };
        
        async Task<RawResponse?> IsErrorResponse() =>
            response.Content.Headers.ContentType?.MediaType == "application/json"
                ? await JsonSerializer.DeserializeAsync<RawResponse>(await response.Content.ReadAsStreamAsync(cancellationToken),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }, cancellationToken)
                : null;
    }
}